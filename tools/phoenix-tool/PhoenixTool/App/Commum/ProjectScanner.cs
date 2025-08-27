namespace PhoenixTool.App.Commum;

public static class ProjectScanner
{
    public static string[] SearchForCsProjFiles(string? path = null)
    {
        var files = Directory.GetFiles(
            path: path ?? Directory.GetCurrentDirectory(),
            searchPattern: "*.csproj",
            searchOption: SearchOption.AllDirectories);

        if (files is null)
        {
            return [];
        }

        var filePathWithoutFileName = files
            .Select(Path.GetDirectoryName)
            .Where(x => x is not null)
            .Cast<string>()
            .Distinct()
            .ToArray()
            ;

        return filePathWithoutFileName;
    }
}