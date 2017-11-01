#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif
#define LIGHTS_COUNT 2
matrix World;
matrix View;
matrix Projection;
// Light info
float3 LightPosition[LIGHTS_COUNT];
float3 La[LIGHTS_COUNT];		//Ambient light intensity
float3 Ld[LIGHTS_COUNT];		//Diffuse light intensity
float3 Ls[LIGHTS_COUNT];		//Specular light intensity



// Material info
float3 Ka;			//Ambient reflectivity
float3 Kd;			//Diffuse reflectivity
float3 Ks;			//Specular reflectivity
float Shininess;	//Specular shininess factor

struct VertexShaderInput
{
	float4 Position : POSITION0;
	float Color : COLOR0;
	float3 Normal : NORMAL0;
};

struct VertexShaderOutput
{
	float4 Position : POSITION0;
	float Color : COLOR0;
	float3 Normal : NORMAL0;
};


VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
	VertexShaderOutput output;

	float4 worldPosition = mul(input.Position, World);
	float4 viewPosition = mul(worldPosition, View);
	output.Position = mul(viewPosition, Projection);

	return output;
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	return float4(1,0,0,1);
}

technique BasicColorDrawing
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL VertexShaderFunction();
		PixelShader = compile PS_SHADERMODEL PixelShaderFunction();
	}
};