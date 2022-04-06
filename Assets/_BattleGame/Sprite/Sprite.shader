Shader "Custom/Sprite"
{
    Properties
    {
        _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        _Color ("Color", Color) = (1,1,1,1)
        _SpriteSheet ("SpriteSheet", 2D) = "white" {}
        _SpriteHeight ("SpriteHeight", Float) = 32
        _SpriteWidth ("SpriteWidth", Float) = 32
        _SpriteFrame ("SpriteFrame", Int) = 0
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
        Cull Off
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard alphatest:_Cutoff addshadow

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        // Sprite data
        sampler2D _SpriteSheet;
        struct Input
        {
            float2 uv_SpriteSheet;
        };
        float4 _SpriteSheet_TexelSize;
        float _SpriteHeight;
        float _SpriteWidth;
        int _SpriteFrame;

        // Material data
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        fixed4 sprite (Input IN)
        {
            float2 spriteSheetSize = _SpriteSheet_TexelSize.zw;
            float2 spriteSheetUV = IN.uv_SpriteSheet;
            float2 spriteSize = float2(_SpriteWidth, _SpriteHeight);
            float2 spriteOffset = float2(_SpriteFrame % (spriteSheetSize.x / spriteSize.x), floor(_SpriteFrame / (spriteSheetSize.x / spriteSize.x)));
            //SpriteIndex % ((SpriteSheetSize.X) / PixelSize.X), MathF.Floor(SpriteIndex / (SpriteSheetSize.X / PixelSize.X)));

            float2 spriteCoords = ((spriteSheetUV + spriteOffset) * spriteSize) / spriteSheetSize;
            return tex2D (_SpriteSheet, spriteCoords);
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = sprite(IN) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
