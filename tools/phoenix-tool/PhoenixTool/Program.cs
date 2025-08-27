using Cocona;
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
      Console.WriteLine($"Generating API for {module}.{entity}");

      Console.WriteLine($"You fields:\n");
      foreach (var field in fields)
      {
        Console.WriteLine($"  {field}");
      } 
    })
    .WithDescription("Gen API endpoint");

app.AddCommand("hello", ([Argument(Description = "Name")] string name) =>
    {
      var fruits = AnsiConsole.Prompt(
      new MultiSelectionPrompt<string>()
          .Title("What are your [green]favorite fruits[/]?")
          .NotRequired()
          .PageSize(10)
          .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
          .InstructionsText(
              "[grey](Press [blue]<space>[/] to toggle a fruit, " +
              "[green]<enter>[/] to accept)[/]")
          .AddChoices([
            "Apple", "Apricot", "Avocado",
            "Banana", "Blackcurrant", "Blueberry",
            "Cherry", "Cloudberry", "Coconut",
          ]));

      foreach (var fruit in fruits)
      {
        Console.WriteLine($"You like a {fruit}");
      }
    })
    .WithDescription("Say Hello");

app.Run();
