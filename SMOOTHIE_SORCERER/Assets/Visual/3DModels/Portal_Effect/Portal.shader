Shader "Unlit/Portal"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Mask("Mask",2D) = "white" {}
        //_Rotation("Rotation",Range(0,360)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 150
        //ColorMask RGB
        AlphaToMask On

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _Mask;
            float4 _Mask_ST;

            float _Rotation;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            void Unity_Rotate_Degrees_float
            (float2 UV, float2 center, float rotation, out float2 Out)
            {
                rotation = rotation * (UNITY_PI / 180.0f);
                UV -= center;
                float s = sin(rotation);
                float c = cos(rotation);
                float2x2 rMatrix = float2x2(c, -s, s, c);
                rMatrix *= 0.5;
                rMatrix += 0.5;
                rMatrix = rMatrix * 2 - 1;
                UV.xy = mul(UV.yx, rMatrix);
                UV += center;
                Out = UV;
            }

          

            fixed4 frag(v2f i) : SV_Target
            {
            float u = i.uv.x;
            float v = i.uv.y;
            float center = 0.5;
            float2 uv = 0;
            Unity_Rotate_Degrees_float(float2(u, v), center, _Time.y*25, uv);
                // sample the texture
                fixed4 col = tex2D(_MainTex, uv);
                fixed4 mask = tex2D(_Mask, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col*mask;
            }
            ENDCG
        }
    }
}
