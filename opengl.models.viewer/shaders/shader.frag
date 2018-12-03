#version 440

in vec3 surfaceNormal;
in vec3 toLightVector;

out vec4 out_Color;

uniform vec3 lightColor;

void main(void) {
  vec3 unitNormal = normalize(surfaceNormal);
  vec3 unitLightVector = normalize(toLightVector);

  float nDotL = dot(unitNormal, unitLightVector);
  float brightness = max(nDotL, 0.0);
  vec3 diffuse = brightness * lightColor;

  out_Color = vec4(diffuse * vec3(0.75, 0.75, 0.75), 1.0);
}