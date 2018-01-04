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
float3 CameraPosition;

texture ModelTexture;

samplerCUBE  TextureSampler = sampler_state {
	texture = <ModelTexture>;
	magfilter = LINEAR;
	minfilter = LINEAR;
	mipfilter = LINEAR;
	AddressU = Mirror;
	AddressV = Mirror;
};


struct VertexShaderInput
{
	float4 Position : POSITION0;
};

struct VertexShaderInputEnvMapping
{
	float4 Position : POSITION0;
	float3 Normal : NORMAL;
};

struct VertexShaderOutput
{
	float4 Position : POSITION0;
	float3 TextureCoordinate : TEXCOORD0;
};

struct VertexShaderOutputEnvMapping
{
	float4 Position : POSITION0;
	float3 Reflect: TEXCOORD0;
};


VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
	VertexShaderOutput output;

	float4 worldPosition = mul(input.Position, World);
	float4 viewPosition = mul(worldPosition, View);
	output.Position = mul(viewPosition, Projection);

	float4 VertexPosition = mul(input.Position, World);
	output.TextureCoordinate = VertexPosition - CameraPosition;

	return output;
}

VertexShaderOutput VertexShaderEnvMapping(VertexShaderInputEnvMapping input)
{
	VertexShaderOutputEnvMapping output;
	float3 Normal = mul(normalize(input.Normal), World);
	float4 worldPosition = mul(input.Position, World);
	float4 viewPosition = mul(worldPosition, View);
	output.Position = mul(viewPosition, Projection);
	float3 ViewDir = normalize(worldPosition - CameraPosition);
	output.Reflect = reflect(ViewDir, Normal);

	return output;
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
	return texCUBE(TextureSampler, normalize(input.TextureCoordinate));
}

float4 PixelShaderEnvMapping(VertexShaderOutputEnvMapping input) : COLOR0
{
	return texCUBE(TextureSampler, normalize(input.Reflect));
}

technique Main
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL VertexShaderFunction();
		PixelShader = compile PS_SHADERMODEL PixelShaderFunction();
	}
};

technique EnvMapping
{
	pass P0
	{
		VertexShader = compile VS_SHADERMODEL VertexShaderEnvMapping();
		PixelShader = compile PS_SHADERMODEL PixelShaderEnvMapping();
	}
};