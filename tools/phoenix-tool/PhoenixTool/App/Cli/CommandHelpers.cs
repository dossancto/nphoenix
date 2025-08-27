using PhoenixTool.App.Commum;

using Spectre.Console;

namespace PhoenixTool.App.Cli;

public static class CommandHelpers
{
    public static string? GetProjectPath(string? path = null)
    {
        var files = ProjectScanner.SearchForCsProjFiles(path);

        if (files.Length is 0)
        {
            return null;
        }

        if (files.Length is 1)
        {
            return files[0];
        }

        var prompt = new SelectionPrompt<string>()
              .Title("What's your [green]favorite .csproj file[/]?")
              .EnableSearch()
              .PageSize(5)
              .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
              .AddChoices(files);

        return AnsiConsole.Prompt(prompt);
    }
}