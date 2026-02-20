using Aegis.Gateway.Abstractions;
using Aegis.Gateway.Handlers;
using Aegis.Gateway.Middlewares;
using Aegis.Gateway.Repositories;
using Aegis.Gateway.Resolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<IAuthHandler, BearerAuthHandler>();
builder.Services.AddTransient<IAuthHandler, ApiKeyAuthHandler>();
builder.Services.AddTransient<AuthResolver>();

builder.Services.AddSingleton<IApiCredentialRepository, InMemoryApiCredentialRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseMiddleware<AuthMiddleware>();

app.MapControllers();

app.Run();
