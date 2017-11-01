#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_3
	#define PS_SHADERMODEL ps_4_0_level_9_3
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
float IsDirect[LIGHTS_COUNT];


// Material info
float3 Ka;			//Ambient reflectivity
float3 Kd;			//Diffuse reflectivity
float3 Ks;			//Specular reflectivity
float Shininess;	//Specular shininess factor

void processLight(int i, float3 pos, float3 norm, out float3 ambient, out float3 diffuse, out float3 spec)
{
	float4 worldPosition = mul(float4(LightPosition[i], 1), World);
	float4 Position = mul(pos, View);


	float3 s = (float3)0;
	float3 n = normalize(norm);
	//float vn = mul(mul(float4(norm,0), World), View);
	//s = IsDirect[i] * normalize(-LightPosition[i]) + (1 - IsDirect[i]) * normalize(LightPosition[i] - pos);
	s = IsDirect[i] * normalize(-LightPosition[i]) + (1 - IsDirect[i]) * normalize(LightPosition[i] - pos);
	float3 v = normalize(-Position);
	float3 sv = mul(s, View);
	float3 r = reflect(sv, n);

	ambient = La[i] * Ka;
	float sDotN = max(dot(s, n), 0.0);
	diffuse = Ld[i] * Kd * sDotN;
	spec = Ls[i] * Ks * pow(max(dot(r, v), 0.0), Shininess);
}
struct VertexShaderInput
{
	float4 Position : POSITION0;
	float4 Color : COLOR0;
	float3 Normal : NORMAL0;
};

struct VertexShaderOutput
{
	float4 Position : POSITION0;
	float4 Color : COLOR0;
	float3 Normal : NORMAL0;
	float3 WorldPos : TEXCOORD0;
};


struct VertexShaderInputTx
{
	float4 Position : POSITION0;
	float3 Normal : NORMAL0;
	float2 TextCoords : TEXCOORD0;
};

struct VertexShaderOutputTx
{
	float4 Position : POSITION0;
	float2 TextCoords : TEXCOORD0;
	float3 Normal : NORMAL0;
	float3 WorldPos : TEXCOORD1;
};

sampler TextureSampler : register(s0);

VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
	VertexShaderOutput output;

	float4 worldPosition = mul(input.Position, World);
	float4 viewPosition = mul(worldPosition, View);
	output.Position = mul(viewPosition, Projection);
	output.Color = input.Color;
	output.Normal = input.Normal;
	output.WorldPos = worldPosition;

	return output;
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	float3 ambientSum = (float3)0;
	float3 diffuseSum = (float3)0;
	float3 specSum = (float3)0;
	// output params
	float3 ambient, diffuse, spec;
	//ambientSum = float3(0.1, 0.1, 0.1);
	//diffuseSum = float3(0.1, 0.1, 0.1);
	//specSum = float3(0.1, 0.1, 0.1);
	for (int i = 0; i<LIGHTS_COUNT; i++)
	{
		processLight(i, input.WorldPos, input.Normal, ambient, diffuse, spec);
		ambientSum += ambient;
		diffuseSum += diffuse;
		specSum += spec;
	}
	ambientSum = saturate(ambientSum);
	diffuseSum = saturate(diffuseSum);
	specSum = saturate(specSum);
	ambientSum /= LIGHTS_COUNT;
	return float4(ambientSum + diffuseSum, 1) * input.Color + float4(specSum, 1);
	//return input.Color;
	//return float4(1,0,0,1);
}

//TEXTURE VERSION

VertexShaderOutputTx VertexShaderTxFunction(VertexShaderInputTx input)
{
	VertexShaderOutputTx output;

	float4 worldPosition = mul(input.Position, World);
	float4 viewPosition = mul(worldPosition, View);
	output.Position = mul(viewPosition, Projection);
	output.TextCoords = input.TextCoords;
	output.Normal = mul(input.Normal, World);
	output.WorldPos = input.Position;
	return output;
}

float4 PixelShaderTxFunction(VertexShaderOutputTx input) : COLOR0
{
	float3 ambientSum = (float3)0;
	float3 diffuseSum = (float3)0;
	float3 specSum = (float3)0;
	// output params

	float3 ambient, diffuse, spec;
	//ambientSum = float3(0.1, 0.1, 0.1);
	//diffuseSum = float3(0.1, 0.1, 0.1);
	//specSum = float3(0.1, 0.1, 0.1);
	for (int i = 0; i<LIGHTS_COUNT; i++)
	{
		processLight(i, input.WorldPos, input.Normal, ambient, diffuse, spec);
		ambientSum += ambient;
		diffuseSum += diffuse;
		specSum += spec;
	}

	float4 tex = float4(1, 0, 0, 1);
	ambientSum /= LIGHTS_COUNT;
	return float4(ambientSum + diffuseSum, 1) * tex + float4(specSum, 1);
	//return input.Color;
	//return float4(1,0,0,1);
}

technique NoTextureTeq
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL VertexShaderFunction();
		PixelShader = compile PS_SHADERMODEL PixelShaderFunction();
	}
};

technique TextureTeq
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL VertexShaderTxFunction();
		PixelShader = compile PS_SHADERMODEL PixelShaderTxFunction();
	}
};