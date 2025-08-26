using DotNetEnv;

using PhoenixApi.Modules.Commum;

Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCommumModule()
    ;

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();