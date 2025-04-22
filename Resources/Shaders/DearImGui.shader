Shader "DearImGui"
{
    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "PreviewType" = "Plane" }

        LOD 100
        Cull Off
        Lighting Off
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Blend One OneMinusSrcAlpha

        Pass
        {
            Name "Dear ImGui Procedural"
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0

            #include "UnityCG.cginc"

            struct ImVert
            {
                float2 vertex : POSITION;
                float2 uv : TEXCOORD0;
                uint color : TEXCOORD1;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                half4 color : COLOR;
                float4 worldPosition : TEXCOORD1;
            };

            StructuredBuffer<ImVert> _Vertices;
            int _BaseVertex;
            sampler2D _Texture;

            half4 unpack_color(uint c)
            {
                half4 color = half4(
                    (c      ) & 0xff,
                    (c >>  8) & 0xff,
                    (c >> 16) & 0xff,
                    (c >> 24) & 0xff
                ) / 255.0;
                
                #ifndef UNITY_COLORSPACE_GAMMA
                    color.rgb = GammaToLinearSpace(color.rgb);
                #endif
                
                color.rgb *= color.a;
                return color;
            }

            v2f vert(uint id : SV_VertexID)
            {
                v2f OUT;
                UNITY_INITIALIZE_OUTPUT(v2f, OUT);
                
                #if defined(SHADER_API_D3D11) || defined(SHADER_API_XBOXONE)
                id += _BaseVertex;
                #endif
                
                ImVert v = _Vertices[id];
                
                OUT.worldPosition = float4(v.vertex.xy, 0, 1);
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);
                OUT.uv = v.uv;
                OUT.color = unpack_color(v.color);
                
                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                half4 texColor = tex2D(_Texture, IN.uv);
                texColor.rgb *= texColor.a;
                return IN.color * texColor;
            }
            ENDCG
        }
    }
}
