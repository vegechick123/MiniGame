

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
            float4 _LightSourceTexture_TexelSize;
            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeScreenPos(o.pos);
                o.uv = TRANSFORM_TEX(v.uv, _LightTex);

                return o;
            }


            half4 frag(v2f i) : SV_Target
            {
                float2 uv =i.grabPos.xy/i.grabPos.w;

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
