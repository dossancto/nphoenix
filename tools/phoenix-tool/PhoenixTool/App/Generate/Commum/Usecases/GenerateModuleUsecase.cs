using PhoenixTool.App.Generate.Commum.Dtos;

namespace PhoenixTool.App.Generate.Commum.Usecases;

public record GenerateModuleUsecaseOutput
(
    bool ModuleAlreadyExists
);

public static class GenerateModuleUsecase
{
    public static GenerateModuleUsecaseOutput TryCreateModule(ScaffoldInput input, ProjectMetadata metadata, string pathToModule)
    {
        return new(true);
    }
}