// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Sprites/Revert"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
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
        GrabPass
        {
            "_BackgroundTexture"
        }
        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
        CGPROGRAM
            #pragma vertex MySpriteVert
            #pragma fragment MySpriteFrag
            #pragma target 2.0
            #pragma multi_compile_instancing
            #pragma multi_compile_local _ PIXELSNAP_ON
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
            #include "UnitySprites.cginc"
            struct myappdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct myv2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                float4 grabPos : TEXCOORD1;
                UNITY_VERTEX_OUTPUT_STEREO
            };
            sampler2D _LightSourceTexture;
            myv2f MySpriteVert(myappdata_t IN)
            {
                myv2f OUT;

                UNITY_SETUP_INSTANCE_ID (IN);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

                OUT.vertex = UnityFlipSprite(IN.vertex, _Flip);
                OUT.vertex = UnityObjectToClipPos(OUT.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color * _RendererColor;
                OUT.grabPos = ComputeGrabScreenPos(UnityObjectToClipPos(IN.vertex));
                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap (OUT.vertex);
                #endif

                return OUT;
            }
            fixed4 MySpriteFrag(myv2f IN) : SV_Target
            {
                float2 uv =IN.grabPos.xy/IN.grabPos.w;
                uv.y=1-uv.y;
                half4 bgcolor = tex2D(_LightSourceTexture, uv);
                
                fixed4 color = tex2D (_MainTex, IN.texcoord);
                //return color;
                #if ETC1_EXTERNAL_ALPHA
                    fixed4 alpha = tex2D (_AlphaTex, IN.texcoord);
                    color.a = lerp (color.a, alpha.r, _EnableExternalAlpha);
                #endif

                fixed val = bgcolor.r;
                if(val>0.5)
                    color.rgb=1-color.rgb;
                color.rgb*=color.a;
                //color.rgb *= color.a;
                //fixed val = abs(color.r - bgcolor.r);
                
                //fixed4 c = tex2D(_LightTex,IN.texcoord) * IN.color;
                
                return fixed4(color.rgb,color.a);
            }
        ENDCG
        }
        
    }
}
