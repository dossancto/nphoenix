using PhoenixTool.App.Generate.Commum.Dtos;
using PhoenixTool.App.Generate.Commum.Factories;

namespace PhoenixTool.App.Generate.Commum.Usecases;

public static class GenerateSchemeUsecAse
{
    public static void Execute(ScaffoldInput input, ProjectMetadata metadata)
    {
        var pathToModule = Path.Combine(metadata.ProjectPath, "Modules", input.Module);
        var pathToEntities = Path.Combine(pathToModule, "Domain", "Entities");
        var pathToEntityConfiguration = Path.Combine(pathToModule, "Adapters", "Database", "Configurations");

        var entityContent = GenerateEntityFactory.Generate(input, metadata);

        var entityConfiguration = EntityConfigurationFactory.Create(input, metadata);

        Directory.CreateDirectory(pathToModule);
        Directory.CreateDirectory(pathToEntities);
        Directory.CreateDirectory(pathToEntityConfiguration);

        File.WriteAllText(Path.Combine(pathToEntities, $"{input.Entity}.cs"), entityContent);
        File.WriteAllText(Path.Combine(pathToEntityConfiguration, $"{input.Entity}EntityConfiguration.cs"), entityConfiguration);

        var moduleContentOutput = GenerateModuleUsecase.TryCreateModule(input, metadata, pathToModule);
    }
}