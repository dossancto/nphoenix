using PhoenixTool.App.Generate.Commum.Dtos;
using PhoenixTool.App.Generate.Commum.Factories;

namespace PhoenixTool.App.Generate.Commum.Usecases;

public class CreateApiResourceUsecase
{
    public void Create(ScaffoldInput input, ProjectMetadata metadata)
    {
        // FIX: Should only get the path, not the csproj filename. `metadata.ProjectPath` is wrong
        var pathToModule = Path.Combine(metadata.ProjectPath, "Modules", input.Module);

        var moduleAlreadyExists = false;

        var entityContent = GenerateEntityFactory.Generate(input, metadata);

        // TODO: Build the entity configuration
        var entityConfiguration = EntityConfigurationFactory.Create(input, metadata);

        // TODO: Build the endpoint content
        var endpointContent = "";

        // TODO: Create All Folders
        // TODO: Create all files

        if (moduleAlreadyExists)
        {
            // TODO: Recomend user to append the new items on module that already exists
        }
        else
        {
            var moduleContent = "";

            // TODO: Create and store module content.
            // Then recoment to user to add it on Program.cs

        }
    }
}