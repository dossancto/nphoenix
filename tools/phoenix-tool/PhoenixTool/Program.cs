using Cocona;

using PhoenixTool.App.Cli;
using PhoenixTool.App.Commum;
using PhoenixTool.App.Generate.Commum.Dtos;
using PhoenixTool.App.Generate.Commum.Factories;
using PhoenixTool.App.Generate.Commum.Usecases;

using Spectre.Console;

var builder = CoconaApp.CreateBuilder();

var app = builder.Build();

app.AddCommand(
    "gen.api",
    (
     [Argument(Description = "The App module")] string module,
     [Argument(Description = "The entity to be used")] string entity,
     [Argument(Description = "Fields")] List<string> fields
    ) =>
    {
        var choosedFile = CommandHelpers.GetProjectPath();

        if (choosedFile is null)
        {
            AnsiConsole.MarkupLine("[red]No .csproj file found in the current directory[/]");
            return;
        }

        var projectMetadata = ProjectMetadata.FromCsProjPath(choosedFile);
        var scaffoldInput = new ScaffoldInput(
            Module: module,
            Entity: entity,
            Fields: fields
        );

        var res = GenerateEntityFactory.Generate(scaffoldInput, projectMetadata);

        Console.WriteLine(res);
    })
    .WithDescription("Gen API endpoint");

app.AddCommand(
    "gen.scheme",
    (
     [Argument(Description = "The App module")] string module,
     [Argument(Description = "The entity to be used")] string entity,
     [Argument(Description = "Fields")] List<string> fields
    ) =>
    {
        var choosedFile = CommandHelpers.GetProjectPath();

        if (choosedFile is null)
        {
            AnsiConsole.MarkupLine("[red]No .csproj file found in the current directory[/]");
            return;
        }

        var projectMetadata = ProjectMetadata.FromCsProjPath(choosedFile);
        var scaffoldInput = new ScaffoldInput(
            Module: module,
            Entity: entity,
            Fields: fields
        );

        GenerateSchemeUsecAse.Execute(scaffoldInput, projectMetadata);
    })
    .WithDescription("Gen Application Scheme only");

app.Run();