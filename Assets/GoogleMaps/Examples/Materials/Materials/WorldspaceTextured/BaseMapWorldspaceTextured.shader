﻿// BaseMap shader for use on ground/water regions.
// Diffuse and specular lighting, with shadow receiving (but not casing).
Shader "Google/Maps/Shaders/BaseMap Worldspace Textured" {
  Properties {
    _Color ("Color", Color) = (1,1,1,1)
    _MainTex ("Albedo (RGB)", 2D) = "white" {}
    _Glossiness ("Smoothness", Range(0,1)) = 0.5
    _Metallic ("Metallic", Range(0,1)) = 0.0

    // Offset applied to worldspace texture coordinates. Only the first and
    // third (x and z) value of this Vector are used, providing a top-down
    // offset.
    _Offset("Worldspace Offset", Vector) = (0.0, 0.0, 0.0, 0.0)
  }
  SubShader {
    Tags { "RenderType"="Opaque" }

    LOD 200

    // Basemap renders multiple coincident ground plane features so we have to
    // disable z testing (make it always succeed) to allow for overdraw.
    ZTest Always

    CGPROGRAM
    // Physically based Standard lighting model, and enable shadows on all
    // light types.
    #pragma surface surf Standard fullforwardshadows alpha:blend

    // Use shader model 3.0 target, to get nicer looking lighting.
    #pragma target 3.0

    // Input parameters.
    half _Glossiness;
    half _Metallic;
    fixed4 _Color;
    sampler2D _MainTex;
    uniform fixed4 _Offset;
    uniform float4 _MainTex_ST;

    // Vertex input.
    struct Input {
      float3 worldPos;
    };

    // Surface shader itself.
    void surf (Input input, inout SurfaceOutputStandard output) {
      // Convert worldspace position to uv coordinates. Translate x position to
      // u coordinates, and z positions to v coordinates.
      float2 worldspaceUv = float2(
          (input.worldPos.x + _Offset.x) / _MainTex_ST.x,
          (input.worldPos.z + _Offset.z) / _MainTex_ST.y);

      // Albedo comes from worldspace applied texture, tinted by color.
      fixed4 color = tex2D(_MainTex, worldspaceUv) * _Color;
      output.Albedo = color.rgb;

      // Metallic and smoothness come from slider variables.
      output.Metallic = _Metallic;
      output.Smoothness = _Glossiness;
      output.Alpha = color.a;
    }
    ENDCG
  }
  FallBack "Diffuse"
}
