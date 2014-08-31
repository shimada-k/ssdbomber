Shader "Custom/SSDBomber" {
    Properties {
        _SSDBTex ( "Base", 2D ) = "white" {}
        //_EmissionColor("Emission Color", Color) = (1.0, 0.1, 0.1, 1.0)
		//_EmissionTex ("Emission Texture", 2D) = "white" {}
    }

    SubShader {
        Tags {
            "Queue" = "Transparent"
        }

        // First Pass
        Cull Front

        CGPROGRAM
        #pragma surface surf Lambert alpha 
        sampler _SSDBTex;

        struct Input {
            float2 uv_SSDBTex;
            float4 vtxColor : COLOR;
        };

        void surf( Input IN, inout SurfaceOutput o ) {
            half4 color = tex2D( _SSDBTex, IN.uv_SSDBTex );
            o.Albedo = color.rgb;
            o.Alpha = color.a;
        }

        ENDCG

        // Second Pass
        Cull Back

        CGPROGRAM
        #pragma surface surf Lambert alpha 

        sampler _SSDBTex;

        struct Input {
            float2 uv_SSDBTex;
            float4 vtxColor : COLOR;
        };

        void surf( Input IN, inout SurfaceOutput o ) {
            half4 color = tex2D( _SSDBTex, IN.uv_SSDBTex );
            o.Albedo = color.rgb;
            o.Alpha = color.a;
        }

        ENDCG 
    } 
}

