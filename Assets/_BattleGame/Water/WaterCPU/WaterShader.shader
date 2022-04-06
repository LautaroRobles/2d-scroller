Shader "Custom/WaterShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BumpMap1("Bumpmap1", 2D) = "bump" {}
        _BumpMap2("Bumpmap2", 2D) = "bump" {}
		_BumpMapStrenght ("Bumpmap Strength", Range(0, 1)) = 0.1
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _WaterFogColor ("Water Fog Color", Color) = (0, 0, 0, 0)
		_WaterFogDensity ("Water Fog Density", Range(0, 2)) = 0.1

        _WaveA ("WaveA (dir, steepness, wavelength)", Vector) = (1, 0, 0.5, 10)
        _WaveB ("WaveB", Vector) = (1, 0.5, 0.5, 10)
        _WaveC ("WaveC", Vector) = (1, 0, 0.5, 10)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        LOD 200
        GrabPass { "_WaterBackground" }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard vertex:vert alpha

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        // Start of wave simulations

        float4 _WaveA, _WaveB, _WaveC;

        float3 GerstnerWave(
            float4 wave, float3 p, inout float3 tangent, inout float3 binormal
        ) {
            float steepness = wave.z;
            float wavelength = wave.w;
            float k = 2 * UNITY_PI / wavelength;
            float c = sqrt(9.8 / k);
            float2 d = normalize(wave.xy);
            float f = k * (dot(d, p.xz) - c * _Time.y);
            float a = steepness / k;

            tangent += float3(
                -d.x * d.x * (steepness * sin(f)),
                d.x * (steepness * cos(f)),
                -d.x * d.y * (steepness * sin(f))
            );
            binormal += float3(
                -d.x * d.y * (steepness * sin(f)),
                d.y * (steepness * cos(f)),
                -d.y * d.y * (steepness * sin(f))
            );
            return float3(
                d.x * (a * cos(f)),
                a * sin(f),
                d.y * (a * cos(f))
            );
        }

        void vert(inout appdata_full vertexData)
        {
            float3 gridPoint = vertexData.vertex.xyz;
            float3 tangent = float3(1, 0, 0);
            float3 binormal = float3(0, 0, 1);
            float3 p = gridPoint;

            gridPoint = mul(unity_ObjectToWorld, vertexData.vertex).xyz;

            p += GerstnerWave(_WaveA, gridPoint, tangent, binormal);
            p += GerstnerWave(_WaveB, gridPoint, tangent, binormal);
            p += GerstnerWave(_WaveC, gridPoint, tangent, binormal);
            float3 normal = normalize(cross(binormal, tangent));
            vertexData.vertex.xyz = p;
            vertexData.normal = normal + vertexData.normal;
        }
        
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap1;
            float2 uv_BumpMap2;
            float3 worldNormal; INTERNAL_DATA
            float4 screenPos;
        };

        sampler2D _MainTex;
        sampler2D _BumpMap1, _BumpMap2;

        half _Glossiness;
        half _Metallic;
        float4 _WaterFogColor;
		float _WaterFogDensity;
        float _BumpMapStrenght;
        fixed4 _Color;
        sampler2D _CameraDepthTexture, _WaterBackground;
        float4 _CameraDepthTexture_TexelSize;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float3 ColorBelowWater (float4 screenPos, half3 normal) {
            float2 uvOffset = normal.xy;
            uvOffset.y *= _CameraDepthTexture_TexelSize.z * abs(_CameraDepthTexture_TexelSize.y);

            float2 uv = (screenPos.xy + uvOffset) / screenPos.w;
            float backgroundDepth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, uv));
            float surfaceDepth = UNITY_Z_0_FAR_FROM_CLIPSPACE(screenPos.z);
            float depthDifference = backgroundDepth - surfaceDepth;

            if (depthDifference < 0) {
                uv = screenPos.xy / screenPos.w;
                #if UNITY_UV_STARTS_AT_TOP
                    if (_CameraDepthTexture_TexelSize.y < 0) {
                        uv.y = 1 - uv.y;
                    }
                #endif
                backgroundDepth =
                    LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, uv));
                depthDifference = backgroundDepth - surfaceDepth;
            }

            float3 backgroundColor = tex2D(_WaterBackground, uv).rgb;
            float fogFactor = exp2(-_WaterFogDensity * depthDifference);

	        return lerp(_WaterFogColor, backgroundColor, fogFactor);
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

            float4 normal1 = tex2D(_BumpMap1, IN.uv_BumpMap1 + float2(_Time.x, -_Time.y) * 0.03);
            float4 normal2 = tex2D(_BumpMap1, IN.uv_BumpMap1 + float2(_Time.x, _Time.y) * 0.05);
            float4 normal3 = tex2D(_BumpMap2, IN.uv_BumpMap2 + float2(-_Time.x, _Time.y) * 0.07);
            float4 normal4 = tex2D(_BumpMap2, IN.uv_BumpMap2 + float2(-_Time.x, -_Time.y) * 0.09);
            float4 noNormal = float4(0.5, 0.5, 1, 1);
            float4 normal = (normal1 + normal2 + normal3 + normal4) * 0.25;

            half3 finalNormal = UnpackNormal(lerp(noNormal, normal, _BumpMapStrenght));

            o.Normal = finalNormal;
            o.Albedo = ColorBelowWater(IN.screenPos, o.Normal);
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
}
