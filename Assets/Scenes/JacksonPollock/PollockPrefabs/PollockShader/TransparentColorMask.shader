Shader "Custom/TransparentColorMask" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
     _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	 _Mask("ColorMask (Red = Prim Green = Sec Blue = Ter)", 2D) = "white" {} // mask texture
	    _ColorPrim("Primary Color", Color) = (0.5,0.5,0.5,1) // primary color, replaces the red masked area
	        _Value1("Primary: Blend Main Texture", Range(0,1)) = 0.5 // blend value with the original texture
		_ColorSec("Secondary Color", Color) = (0.5,0.5,0.5,1) // secondary color, replaces green masked area
		    _Value2("Secondary: Blend Main Texture", Range(0,1)) = 0.5// blend value with the original texture
		_ColorTert("Tertiary Color", Color) = (0.5,0.5,0.5,1)// tertiary color, replaces blue masked area
			_Value3("Tertiary: Blend Main Texture", Range(0,1)) = 0.5// blend value with the original texture
	}
	SubShader {
		Tags { "Queue"="Transparent" "IgnoreProjector"="False" "RenderType"="Transparent" }
		LOD 100
		
		Lighting off

		CGPROGRAM
		
		#pragma surface surf Lambert alpha

		#pragma target 3.0

		struct Input {
			float2 uv_MainTex;
		};

		sampler2D _MainTex;
	    sampler2D _Mask; //Mask Texture
		float4 _Color, _ColorPrim, _ColorSec, _ColorTert;// custom colors
		float _Value1, _Value2, _Value3;// original texture blend values


		void surf (Input IN, inout SurfaceOutput o) {
		    half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			half4 m = tex2D(_Mask, IN.uv_MainTex); // mask based on the uvs

			// the 3 custom colours multiplied by the mask , so it only affects the masked areas,
			// also multiplied by the original texture based on a blend value slider
			float3 PrimaryColor = _ColorPrim * m.r + ((c.rgb * _Value1) * m.r);
		    float3 SecondaryColor = _ColorSec * m.g + ((c.rgb * _Value2) * m.g);
			float3 TertiaryColor = _ColorTert * m.b + ((c.rgb * _Value3) * m.b);

			// the part of the model thats not affected by the colour customisation
			float3 NonMasked = c.rgb * (1 - m.r - m.g - m.b);

			// all parts added together form the new look for the model
			o.Albedo =  NonMasked  + PrimaryColor + SecondaryColor + TertiaryColor;
			o.Alpha = c.a ;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
