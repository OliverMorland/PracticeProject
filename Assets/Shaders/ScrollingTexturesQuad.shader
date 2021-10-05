Shader "Oliver/ScrollingTextures"
{
    Properties
    {
        _TopTex ("Top Texture", 2D) = "white" {}
        _BottomTex("Bottom Texture", 2D) = "white" {}
        _TopXSpeed("Top X Speed", Range(0, 3)) = 1
        _BottomXSpeed("Bottom X Speed", Range(0, 3)) = 0.3
        _Brightness("Brightness", Range(0, 3)) = 1
        _Alpha("Translucency", Range(0, 1)) = 0.5
    }
    SubShader
    {

        CGPROGRAM
        #pragma surface surf Lambert alpha:fade

        sampler2D _TopTex;
        sampler2D _BottomTex;
        float _TopXSpeed;
        float _BottomXSpeed;
        float _WaveYSpeed;
        float _WaveYAmplitude;
        float _Brightness;
        float _Alpha;

        struct Input
        {
            float2 uv_TopTex;
            float2 uv_BottomTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            float2 topUVs = float2(IN.uv_TopTex.x + _Time.x * _TopXSpeed, IN.uv_TopTex.y);
            float2 bottomUVs = float2(IN.uv_BottomTex.x + _Time.x * _BottomXSpeed, IN.uv_BottomTex.y);
            o.Emission = _Brightness * (tex2D(_TopTex, topUVs).rgb + tex2D(_BottomTex, bottomUVs)).rgb / 2;
            o.Alpha = _Alpha;
        }


        ENDCG
    }
    FallBack "Diffuse"
}
