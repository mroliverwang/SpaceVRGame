Shader "Space/PlanetAnimatingCloudsSpecular" 
{
    Properties 
    {
		_MainTex ("Main Texture", 2D) = "white" {}
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
        _DispTex ("Mask Texture", 2D) = "gray" {}
        _RampTex ("Colors (RGB)", 2D) = "white" {}
		_RimColor ("Rim Color", Color) = (0.5,0.5,0.5,0)
		_RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
        _ChannelFactor ("ChannelFactor (r,g,b)", Vector) = (1,0,0)
    }
    SubShader 
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf BlinnPhong nolightmap
        #pragma target 3.0
		
        sampler2D _MainTex;
		half _Shininess;
        sampler2D _DispTex;
        float3 _ChannelFactor;
        float2 _Range;
        float _ClipRange;
        sampler2D _RampTex;
		float4 _RimColor;
		float _RimPower;

        struct Input 
        {
            float2 uv_MainTex;
            float2 uv_DispTex;
			float3 viewDir;
        };

        void surf (Input IN, inout SurfaceOutput o) 
		{
			half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
			float4 dcolor = tex2D (_DispTex, IN.uv_DispTex);
			float d = (dcolor.r*_ChannelFactor.r + dcolor.g*_ChannelFactor.g + dcolor.b*_ChannelFactor.b);
			half4 clouds = tex2D (_RampTex, float2(d,0.5));
			half4 tex = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = lerp( tex, clouds.rgb, clouds.a) + _RimColor.rgb * pow (rim, _RimPower);
			o.Gloss = tex.a * (1-clouds.a);
			o.Specular = _Shininess;
		}
		ENDCG
	}
    Fallback "Diffuse"
}
