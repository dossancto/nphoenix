namespace PhoenixTool.App.Commum;

public static class ProjectScanner
{
  public static string[] SearchForCsProjFiles()
  {
    var files = Directory.GetFiles(
        path: Directory.GetCurrentDirectory(),
        searchPattern: "*.csproj",
        searchOption: SearchOption.AllDirectories);

    return files.Distinct().ToArray();
  }
}
