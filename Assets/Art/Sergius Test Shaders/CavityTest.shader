Shader "Custom/CavityTest"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (0.2, 0.2, 0.2, 1) // Solid face color
        _WireColor ("Wireframe Glow Color", Color) = (1, 0.5, 0, 1) // Default: Orange glow
        _WireGlow ("Wire Glow Intensity", Range(0, 10)) = 2
        _WireThickness ("Wire Thickness", Range(0.001, 0.1)) = 0.02
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline" }
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float4 texcoord : TEXCOORD0; // Stores barycentric coordinates
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 normalWS : TEXCOORD0;
                float3 barycentric : TEXCOORD1;
            };

            half4 _BaseColor;
            half4 _WireColor;
            float _WireGlow;
            float _WireThickness;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionCS = TransformObjectToHClip(IN.positionOS);
                OUT.normalWS = TransformObjectToWorldNormal(IN.normalOS);
                OUT.barycentric = IN.texcoord.xyz; // Use barycentric for edges
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                // Use screen-space derivatives to detect wire edges
                float3 dFdx_b = fwidth(IN.barycentric);
                float3 dFdy_b = fwidth(IN.barycentric);
                float3 edgeFactor = smoothstep(_WireThickness, _WireThickness * 1.5, IN.barycentric / (dFdx_b + dFdy_b));

                // Combine all three edges
                float edgeIntensity = min(edgeFactor.x, min(edgeFactor.y, edgeFactor.z));

                // Apply wireframe glow only on edges
                half3 wireGlow = _WireColor.rgb * edgeIntensity * _WireGlow;

                // Final color: Solid base color + emissive wireframe
                half3 finalColor = _BaseColor.rgb + wireGlow;
                return half4(finalColor, 1);
            }
            ENDHLSL
        }
    }
}