using DotNetEnv;

using PhoenixApi.Modules.Commum;
using PhoenixApi.Modules.Todos;

using Scalar.AspNetCore;

Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCommumModule()
    .AddTodosModule()
    ;

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseTodosModule();

app.UseHttpsRedirection();

app.Run();