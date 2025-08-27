namespace PhoenixTool.App.Commum;

public static class ProjectScanner
{
  public static string[] SearchForCsProjFiles(string? path = null)
  {
    var files = Directory.GetFiles(
        path: path ?? Directory.GetCurrentDirectory(),
        searchPattern: "*.csproj",
        searchOption: SearchOption.AllDirectories);

    return files.Distinct().ToArray();
  }
}
