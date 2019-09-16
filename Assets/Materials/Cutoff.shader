Shader "Custom/Transition"
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white" {}
		_Tint("Main Texture Tint", Color) = (1, 1, 1, 1)
		_TransitionTex("Transition Texture", 2D) = "white" {}
		_Cutoff("Cutoff" , Range(0, 1)) = 0
		_Fade("Fade", Range(0, 1)) = 0
		_Color("Cutoff Color", Color) = (1, 1, 1, 1)
	}

	Subshader
	{
		Tags {"Queue"="Transparent" "RenderType"="Transparent" }
        LOD 50

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _TransitionTex;
			float _Cutoff;
			fixed4 _Color;
			float _Fade;
			float4 _Tint;

			struct VertexData {
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv1 : TEXCOORD0;
			};

			struct Interpolators {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
				float2 uv1 : TEXCOORD0;
			};

			Interpolators MyVertexProgram (VertexData v) 
			{
				Interpolators i;
				i.position = UnityObjectToClipPos(v.position);
				i.uv = v.uv;
				i.uv1 = v.uv;

				// #if UNITY_UV_STARTS_AT_TOP
				// if(_MainTex_TexelSize.y < 0)
				// 	i.uv1.y = 1 - i.uv1.y;
				// #endif
				return i;
			}

			float4 MyFragmentProgram (Interpolators i) : SV_TARGET 
			{
				fixed4 transit = tex2D(_TransitionTex, i.uv);
				fixed4 col = tex2D(_MainTex, i.uv) * _Tint;
				col.a = 0;

				if(transit.b < _Cutoff)
					return col = lerp(col, _Color, _Fade);

				return col;
			}

			ENDCG
		}
	}

 Fallback "Transparent/VertexLit"
}