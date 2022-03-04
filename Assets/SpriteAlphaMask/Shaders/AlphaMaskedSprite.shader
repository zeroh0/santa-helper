// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Custom/AlphaMaskedSprite"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaSpriteMaskTex ("Full screen Texture with transparency data in R channel", 2D) = "white" {}
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
        CGPROGRAM
            #pragma vertex ams_SpriteVert
            #pragma fragment ams_SpriteFrag
            #pragma target 2.0
            #pragma multi_compile_instancing
            #pragma multi_compile _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"

            struct ams_v2f
			{
			    float4 vertex   : SV_POSITION;
			    fixed4 color    : COLOR;
			    float2 texcoord : TEXCOORD0;
			    float4 screenpos : TEXCOORD1;
			    UNITY_VERTEX_OUTPUT_STEREO
			};

			ams_v2f ams_SpriteVert(appdata_t IN)
			{
				ams_v2f OUT;
				v2f legacy_OUT = SpriteVert(IN);

				OUT.vertex = legacy_OUT.vertex;
				OUT.color = legacy_OUT.color;
				OUT.texcoord = legacy_OUT.texcoord;
				OUT.screenpos = ComputeScreenPos(legacy_OUT.vertex);

				return OUT;
			}

            sampler2D _AlphaSpriteMaskTex;

			fixed4 ams_SpriteFrag(ams_v2f IN) : SV_Target
			{
			    fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
			    fixed4 alpha_sprite_mask = tex2D(_AlphaSpriteMaskTex, IN.screenpos.xy / IN.screenpos.w );
			    c.a *= alpha_sprite_mask.r;
			    c.rgb *= c.a;

			    return c;
			}
        ENDCG
        }
    }
}
