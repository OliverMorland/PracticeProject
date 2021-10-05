Shader "Oliver/ExpandingRings"
{
    Properties
    {
        _MainTex ("Top Texture", 2D) = "white" {}
        _CubeMap("Cube Map", CUBE) = "white" {}
        _Frequency("Frequency", float) = 100
        _Speed("speed", float) = 200
        _Brightness("Brightness", float) = 1
        _FauxWaveHeight("Faux Wave Height", Range(0.1, 8)) = 1
    }
    SubShader
    {

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        samplerCUBE _CubeMap;
        float _Frequency;
        float _Speed;
        float _Brightness;
        float _FauxWaveHeight;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldRefl; INTERNAL_DATA
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            half4 col = tex2D(_MainTex, IN.uv_MainTex);

            half u = IN.uv_MainTex.x;
            half v = IN.uv_MainTex.y;
            half opp = 0.5 - u;
            half adj = 0.5 - v;
            half r = sqrt(pow(opp, 2) + pow(adj, 2)); //Distance from center of tex

            half amp = sin(r * _Frequency - _Time.x*_Speed);
            half diffAmp = ddx(amp);
           
            o.Normal = normalize(half3(opp * diffAmp, adj * diffAmp, _FauxWaveHeight));
            o.Emission = texCUBE(_CubeMap, WorldReflectionVector(IN, o.Normal)) * _Brightness;
        }

        half2 GetPolarCoords(float2 uv_tex)
        {
            half u = uv_tex.x;
            half v = uv_tex.y;
            half opp = 0.5 - u;
            half adj = 0.5 - v;
            half r = sqrt(pow(opp, 2) + pow(adj, 2));
            half ang = 0; 
            return half2(r, ang);
        }

        ENDCG
    }
    FallBack "Diffuse"
}
