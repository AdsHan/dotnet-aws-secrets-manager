using SecretsManager.API.Configuration;
using SecretsManager.API.SecretsManager;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction()) builder.Configuration.AddSecretsManagerConfiguration(builder.Configuration, builder.Environment.EnvironmentName);

builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddSecretsManagerOptionsConfiguration();

var app = builder.Build();

app.UseApiConfiguration();
app.UseSwaggerConfiguration();

app.Run();