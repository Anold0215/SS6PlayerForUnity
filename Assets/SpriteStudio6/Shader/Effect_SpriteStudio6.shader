﻿//
//	SpriteStudio6 Player for Unity
//
//	Copyright(C) Web Technology Corp.
//	All rights reserved.
//
Shader "Custom/SpriteStudio6/SS6PU/Effect"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		[PerRendererData] _AlphaTex("External Alpha", 2D) = "white" {}
		[PerRendererData] _EnableExternalAlpha("Enable External Alpha", Float) = 0

		[Enum(UnityEngine.Rendering.BlendMode)] _BlendSource("Blend Source", Float) = 0
		[Enum(UnityEngine.Rendering.BlendMode)] _BlendDestination("Blend Destination", Float) = 0
		[Enum(UnityEngine.Rendering.BlendOp)] _BlendOperation("Blend Operation", Float) = 0
		[Enum(UnityEngine.Rendering.CompareFunction)] _CompareStencil("Compare Stencil", Float) = 0
		[Toggle] _ZWrite("Write Z Buffer", Float) = 0

		[Toggle(PS_NOT_DISCARD)] _NotDiscardPixel("Not Discard Pixel", Float) = 0
		[Toggle(PS_OUTPUT_PMA)] _OutputPixelPMA("Output PreMultiplied Alpha", Float) = 0
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}

		Pass
		{
			Cull Off
			ZTest LEqual
			ZWRITE [_ZWrite]
			Stencil
			{
				Ref 1
				ReadMask 1
				Comp[_CompareStencil]
				Pass Keep
			}
			BlendOp [_BlendOperation]
			Blend [_BlendSource] [_BlendDestination]

			CGPROGRAM
			#pragma vertex VS_main
			#pragma fragment PS_main

			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
			#include "UnityCG.cginc"

			#define RESTRICT_SHADER_MODEL_3
			#pragma multi_compile _ PS_NOT_DISCARD
			#pragma multi_compile _ PS_OUTPUT_PMA
			#include "Base/Shader_Data_SpriteStudio6.cginc"
			#include "Base/ShaderVertex_Effect_SpriteStudio6.cginc"
			#include "Base/ShaderPixel_Effect_SpriteStudio6.cginc"
			ENDCG
		}
	}
	FallBack Off
}