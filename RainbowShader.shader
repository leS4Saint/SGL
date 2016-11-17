// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "SGLShaders/RainbowShader" {
	Properties{
		_MainTex("Colare Ramp", 2D) = "white" {}
		_Color("Qolore", Color) = (1, 1, 1, 1)
		_Mod("Coloratoni", Float) = 1
	}
		SubShader{
			Pass{
				CGPROGRAM

#pragma vertex vertuloni
#pragma fragment fragatoni

#include "UnityCG.cginc"

	struct vertexInput 
	{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct vertexOutput 
	{
		float2 uv : TEXCOORD0;
		float4 pos : SV_POSITION;
	};

	vertexOutput vertuloni(vertexInput vInput)
	{
		float scaleX = length(mul(unity_ObjectToWorld, float4(1.0, 0.0, 0.0, 0.0)));
		float scaleY = length(mul(unity_ObjectToWorld, float4(0.0, 1.0, 0.0, 0.0)));
		vertexOutput vertOut;
		vertOut.pos = mul(UNITY_MATRIX_MVP, vInput.vertex);
		vertOut.uv = vInput.uv;
		return vertOut;
	}

	sampler2D _MainTex;

	fixed4 fragatoni(vertexOutput i) : SV_TARGET
	{
		float4 feg = tex2D(_MainTex, (i.pos.xy * sin(_Time * 9) / 100));
		return feg;
	}
				ENDCG
		}
	}
}
