using Cocona;
using PhoenixTool.App.Commum;
using PhoenixTool.App.Generate.Commum.Dtos;
using PhoenixTool.App.Generate.Commum.Factories;
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
      var files = ProjectScanner.SearchForCsProjFiles();

      if (files.Length is 0)
      {
        AnsiConsole.MarkupLine("[red]No .csproj file found in the current directory[/]");
        return;
      }

      string ChoosedFile;

      if (files.Length is 1)
      {
        ChoosedFile = files[0];
      }
      else
      {
        var prompt = new SelectionPrompt<string>()
              .Title("What's your [green]favorite .csproj file[/]?")
              .EnableSearch()
              .PageSize(3)
              .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
              .AddChoices(files);

        ChoosedFile = AnsiConsole.Prompt(prompt);
      }

      Console.WriteLine(ChoosedFile);

      var projectMetadata = ProjectMetadata.FromCsProjPath(ChoosedFile);
      var scaffoldInput = new ScaffoldInput(
          Module: module,
          Entity: entity,
          Fields: fields
      );

      var res = GenerateEntityFactory.Generate(scaffoldInput, projectMetadata);

      Console.WriteLine(res);
    })
    .WithDescription("Gen API endpoint");

app.Run();
