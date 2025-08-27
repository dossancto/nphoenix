using PhoenixTool.App.Generate.Commum.Dtos;
using PhoenixTool.App.Generate.Commum.Extensions;
using PhoenixTool.App.Generate.Commum.Factories;

namespace PhoenixTool.App.Generate.Commum.Usecases;

public record GenerateModuleUsecaseOutput
(
    bool ModuleAlreadyExists
);

public static class GenerateModuleUsecase
{
    public static GenerateModuleUsecaseOutput TryCreateModule(ScaffoldInput input, ProjectMetadata metadata, string pathToModule)
    {
        var formatedModuleName = StringExtensions.ToPascalCase(input.Module);

        var pathToModuleFile = Path.Combine(pathToModule, $"{formatedModuleName}Module" + ".cs");

        var moduleAlreadyExists = Path.Exists(pathToModuleFile);

        if (moduleAlreadyExists)
        {
            return new(true);
        }

        Directory.CreateDirectory(pathToModule);

        var moduleContent = GenerateModuleFactory.Generate(input, metadata);

        File.WriteAllText(pathToModuleFile, moduleContent);

        return new(false);
    }
}