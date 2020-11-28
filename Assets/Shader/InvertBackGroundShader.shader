//// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

//Shader "Sprites/TwoSizeShader"
//{
//    Properties
//    {
//        _LightTex ("Light Texture", 2D) = "white" {}
//        _ShadowTex ("Shadow Texture", 2D) = "black" {}
//        _LightColor("LightCol", Color) = (1.0,1.0,1.0,1.0)
//        _ShadowColor("ShadowCol", Color) = (0.0,0.0,0.0,1.0)
//        _Color ("Tint", Color) = (1,1,1,1)
//        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
//        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
//        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
//        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
//        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
//    }

//    SubShader
//    {
//        Tags
//        {
//            "Queue"="Transparent"
//            "IgnoreProjector"="True"
//            "RenderType"="Transparent"
//            "PreviewType"="Plane"
//            "CanUseSpriteAtlas"="True"
//        }

//        Cull Off
//        Lighting Off
//        ZWrite Off
//        Blend One OneMinusSrcAlpha
//        GrabPass
//        {
//            "_BackgroundTexture"
//        }
//        Pass
//        {
//        CGPROGRAM
//            #pragma vertex SpriteVert
//            #pragma fragment MySpriteFrag
//            #pragma target 2.0
//            #pragma multi_compile_instancing
//            #pragma multi_compile_local _ PIXELSNAP_ON
//            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
//            #include "UnitySprites.cginc"
//            sampler2D _LightTex;
//            sampler2D _ShadowTex;
//            sampler2D _BackgroundTexture;
//            struct myappdata_t
//            {
//                float4 vertex   : POSITION;
//                float4 color    : COLOR;
//                float2 texcoord : TEXCOORD0;
//                UNITY_VERTEX_INPUT_INSTANCE_ID
//            };

//            struct myv2f
//            {
//                float4 vertex   : SV_POSITION;
//                fixed4 color    : COLOR;
//                float2 texcoord : TEXCOORD0;
//                float4 grabPos : TEXCOORD1;
//                UNITY_VERTEX_OUTPUT_STEREO
//            };
//            myv2f SpriteVert(myappdata_t IN)
//            {
//                myv2f OUT;

//                UNITY_SETUP_INSTANCE_ID (IN);
//                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

//                OUT.vertex = UnityFlipSprite(IN.vertex, _Flip);
//                OUT.vertex = UnityObjectToClipPos(OUT.vertex);
//                OUT.texcoord = IN.texcoord;
//                OUT.color = IN.color * _Color * _RendererColor;
//                OUT.grabPos = ComputeGrabScreenPos(UnityObjectToClipPos(IN.vertex));
//                #ifdef PIXELSNAP_ON
//                OUT.vertex = UnityPixelSnap (OUT.vertex);
//                #endif

//                return OUT;
//            }
//            fixed4 MySpriteFrag(myv2f IN) : SV_Target
//            {
//                //half4 bgcolor = tex2Dproj(_BackgroundTexture, IN.grabPos);
//                //return 1 - bgcolor;
//                //fixed4 c = tex2D(_LightTex,IN.texcoord) * IN.color;
//                fixed4 color = tex2D (_MainTex, IN.texcoord);

//                #if ETC1_EXTERNAL_ALPHA
//                    fixed4 alpha = tex2D (_AlphaTex, IN.texcoord);
//                    color.a = lerp (color.a, alpha.r, _EnableExternalAlpha);
//                #endif

//                color.rgb *= color.a;
//                return color;
//            }
//        ENDCG
//        }
//    }
//}
// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)


Shader "GrabPassInvert"
{
        Properties
        {
            _LightTex ("Light Texture", 2D) = "white" {}
            _ShadowTex ("Shadow Texture", 2D) = "black" {}
            _LightColor("LightCol", Color) = (1.0,1.0,1.0,1.0)
            _ShadowColor("ShadowCol", Color) = (0.0,0.0,0.0,1.0)
        }
    SubShader
    {
         //Draw ourselves after all opaque geometry
        Tags { "Queue" = "Transparent" }
        Cull Off
        Lighting Off
        ZWrite Off


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            struct v2f
            {
                float4 grabPos : TEXCOORD0;
                float4 pos : SV_POSITION;
                float2 uv :TEXCOORD1;
            };
            sampler2D _LightTex;
            float4 _LightTex_ST;
            sampler2D _ShadowTex;
            float4 _ShadowTex_ST;
            sampler2D _LightSourceTexture;
            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.pos);
                o.uv = TRANSFORM_TEX(v.uv, _LightTex);
                return o;
            }


            half4 frag(v2f i) : SV_Target
            {
                float2 uv =i.grabPos.xy/i.grabPos.w;
                uv.y=1-uv.y;
                half4 bgcolor = tex2D(_LightSourceTexture, uv);
  
                fixed4 lightCol = tex2D(_LightTex, i.uv);
                lightCol.rgb =lightCol.rgb*lightCol.a+bgcolor.rgb*(1-lightCol.a);
                fixed4 shadowCol = tex2D(_ShadowTex, i.uv);
                shadowCol.rgb=shadowCol.rgb*shadowCol.a+bgcolor*(1-shadowCol.a);
                
                if(bgcolor.r<0.5f)
                    return lightCol;
                else
                    return shadowCol;
            }
            ENDCG
        }

    }
}
//Shader "GrabPassInvert"
//{
//    SubShader
//    {
//        // Draw ourselves after all opaque geometry
//        Tags { "Queue" = "Transparent" }

//        // Grab the screen behind the object into _BackgroundTexture
//        GrabPass
//        {
//            "_BackgroundTexture"
//        }
//        Cull Off
//        Lighting Off
//        ZWrite Off
//        // Render the object with the texture generated above, and invert the colors
//        Pass
//        {
//            CGPROGRAM
//            #pragma vertex vert
//            #pragma fragment frag
//            #include "UnityCG.cginc"

//            struct v2f
//            {
//                float4 grabPos : TEXCOORD0;
//                float4 pos : SV_POSITION;
//            };

//            v2f vert(appdata_base v) {
//                v2f o;
//                // use UnityObjectToClipPos from UnityCG.cginc to calculate 
//                // the clip-space of the vertex
//                o.pos = UnityObjectToClipPos(v.vertex);
//                // use ComputeGrabScreenPos function from UnityCG.cginc
//                // to get the correct texture coordinate
//                o.grabPos = ComputeGrabScreenPos(o.pos);
//                return o;
//            }

//            sampler2D _BackgroundTexture;

//            half4 frag(v2f i) : SV_Target
//            {
//                half4 bgcolor = tex2Dproj(_BackgroundTexture, i.grabPos);
//                return bgcolor;
//            }
//            ENDCG
//        }

//    }
//}