using PhoenixTool.App.Generate.Commum.Dtos;

namespace PhoenixTool.App.Generate.Commum.Factories;

public static class ParseFullEntityModuleFactory
{
  public static void Create(ScaffoldInput input)
  {
    var fieldsDtos = input.Fields
      .Select(FieldTypeDefinition.FromRawString)
      .ToList();

  }
}
