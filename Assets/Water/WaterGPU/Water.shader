Shader "Custom/Water"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _HeightMap ("Height Map", 2D) = "white" {}
        _Displacement ("Displacement", float) = 20
        _HeightMapResolution ("Height Map Resolution", float) = 128
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Frequency ("_Frequency", float) = 0.5
        _AnimationSpeed ("_AnimationSpeed", float) = 1
        _Amplitude ("_Amplitude", float) = 2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard vertex:vert addshadow

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        float _Displacement;
        sampler2D _HeightMap;

        float3 displacement(float3 base, appdata_full input) 
        {
            // Water physics displacement
            /*
            float3 heightMap = tex2Dlod(_HeightMap, float4(input.texcoord.xy, 0, 0));
            base.y = (heightMap.r - 0.5) * _Displacement;
            */
            base.y = sin(base.x * 0.5 + _Time.y * 1) * 2;

            return base;
        }

        float _Frequency;
        float _AnimationSpeed;
        float _Amplitude;

        void vert(inout appdata_full data){
            float4 modifiedPos = data.vertex;
            modifiedPos.y += sin(data.vertex.x * _Frequency + _Time.y * _AnimationSpeed) * _Amplitude;
            
            float3 posPlusTangent = data.vertex + data.tangent * 0.01;
            posPlusTangent.y += sin(posPlusTangent.x * _Frequency + _Time.y * _AnimationSpeed) * _Amplitude;

            float3 bitangent = cross(data.normal, data.tangent);
            float3 posPlusBitangent = data.vertex + bitangent * 0.01;
            posPlusBitangent.y += sin(posPlusBitangent.x * _Frequency + _Time.y * _AnimationSpeed) * _Amplitude;

            float3 modifiedTangent = posPlusTangent - modifiedPos;
            float3 modifiedBitangent = posPlusBitangent - modifiedPos;

            float3 modifiedNormal = cross(modifiedTangent, modifiedBitangent);
            data.normal = normalize(modifiedNormal);
            data.vertex = modifiedPos;
        }
        /*
        void vert(inout appdata_full input)
        {
            float4 vertex = input.vertex;
            float3 normal = input.normal;
            float4 tangent = input.tangent;

            float3 position = displacement( vertex, input );
            float3 bitangent = cross( normal, tangent.xyz );
            float3 nt = ( displacement( vertex + tangent.xyz * 0.01, input ) - position );
            float3 nb = ( displacement( vertex + bitangent * 0.01, input ) - position );
            normal = cross( nt, nb );

            input.normal = normalize(normal);
            input.vertex.xyz = position.xyz;
        }
        */

        sampler2D _MainTex;
        sampler2D _BumpMap;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };

        float _HeightMapResolution;

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap - _Time.y * 0.1));
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
