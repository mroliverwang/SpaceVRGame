Shader "Space/PlanetAnimating" 
{
    Properties 
    {
        _DispTex ("Mask Texture", 2D) = "gray" {}
        _RampTex ("Colors (RGB)", 2D) = "white" {}
        _ChannelFactor ("ChannelFactor (r,g,b)", Vector) = (1,0,0)
		_RimColor ("Rim Color", Color) = (0.5,0.5,0.5,0)
		_RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
    }
    SubShader 
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Lambert
        #pragma target 3.0

        sampler2D _DispTex;
        float3 _ChannelFactor;
        float2 _Range;
        float _ClipRange;
        sampler2D _RampTex;
		float4 _RimColor;
		float _RimPower;

        struct Input 
        {
            float2 uv_DispTex;
			float3 viewDir;
        };

        void surf (Input IN, inout SurfaceOutput o) 
		{
			half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
			float3 dcolor = tex2D (_DispTex, IN.uv_DispTex);
			float d = (dcolor.r*_ChannelFactor.r + dcolor.g*_ChannelFactor.g + dcolor.b*_ChannelFactor.b);
			half3 clouds = tex2D (_RampTex, float2(d,0.5)).rgb + _RimColor.rgb * pow (rim, _RimPower);
			o.Albedo = clouds;
		}
		ENDCG
	}
    Fallback "Diffuse"
}
