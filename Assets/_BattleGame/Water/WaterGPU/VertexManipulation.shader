Shader "Custom/VertexManipulation"
{
    Properties {
		_Color ("Tint", Color) = (0, 0, 0, 1)
		_MainTex ("Texture", 2D) = "white" {}

		_Smoothness ("Smoothness", Range(0, 1)) = 0
		_Metallic ("Metalness", Range(0, 1)) = 0
		[HDR] _Emission ("Emission", color) = (0,0,0)

        _Displacement ("Displacement", float) = 20
        _Resolution ("Resolution", float) = 256
        _HeightMap ("Height Map", 2D) = "white" {}
	}
	SubShader {
		//the material is completely non-transparent and is rendered at the same time as the other opaque geometry
		Tags{ "RenderType"="Opaque" "Queue"="Geometry"}

		CGPROGRAM

		//the shader is a surface shader, meaning that it will be extended by unity in the background 
		//to have fancy lighting and other features
		//our surface shader function is called surf and we use our custom lighting model
		//fullforwardshadows makes sure unity adds the shadow passes the shader might need
		//vertex:vert makes the shader use vert as a vertex shader function
		//addshadows tells the surface shader to generate a new shadow pass based on out vertex shader
		#pragma surface surf Standard fullforwardshadows vertex:vert addshadow
		#pragma target 3.0

        sampler2D _HeightMap;
		sampler2D _MainTex;
		fixed4 _Color;

		half _Smoothness;
		half _Metallic;
		half3 _Emission;

        float _Displacement;
        float _Resolution;

		//input struct which is automatically filled by unity
		struct Input {
			float2 uv_MainTex;
		};

        float3 displacement(float3 base, float2 uv) 
        {
            // Water physics displacement
            float3 heightMap = tex2Dlod(_HeightMap, float4(uv, 0, 0));

            heightMap = lerp(heightMap, 0.5, step(abs(heightMap - 0.5), 0.03));

            //base.y += sin(base.x * 0.1 + _Time.y * 1) * 2;
            base.y += (heightMap.r - 0.5) * _Displacement;

            return base;
        }

		void vert(inout appdata_full data){
            float2 uv = data.texcoord;
			float3 modifiedPos = displacement(data.vertex, uv);
			
			float3 posPlusTangent = displacement(data.vertex + data.tangent * 0.01, uv + (data.tangent.xz * 0.01) / _Resolution);

			float3 bitangent = cross(data.normal, data.tangent);
			float3 posPlusBitangent = displacement(data.vertex + bitangent * 0.01, uv + (bitangent.xz * 0.01) / _Resolution);

			float3 modifiedTangent = posPlusTangent - modifiedPos;
			float3 modifiedBitangent = posPlusBitangent - modifiedPos;

			float3 modifiedNormal = cross(modifiedTangent, modifiedBitangent);
			data.normal = normalize(modifiedNormal);
			data.vertex.xyz = modifiedPos;
		}

		//the surface shader function which sets parameters the lighting function then uses
		void surf (Input i, inout SurfaceOutputStandard o) {
			//sample and tint albedo texture
			//fixed4 col = tex2D(_MainTex, i.uv_MainTex);
			//col *= _Color;
			o.Albedo = _Color;
			//just apply the values for metalness, smoothness and emission
			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
			o.Emission = _Emission;
		}
		ENDCG
	}
	FallBack "Standard"
}
