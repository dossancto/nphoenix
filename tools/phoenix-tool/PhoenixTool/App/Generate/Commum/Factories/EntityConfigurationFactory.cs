using System.Text;

using PhoenixTool.App.Generate.Commum.Dtos;
using PhoenixTool.App.Generate.Commum.Extensions;

namespace PhoenixTool.App.Generate.Commum.Factories;

public static class EntityConfigurationFactory
{
    public static string Create(ScaffoldInput input, ProjectMetadata metadata)
    {
        var fieldsDtos = input.Fields
          .Select(FieldTypeDefinition.FromRawString)
          .ToList();

        var entityName = StringExtensions.ToPascalCase(input.Entity);

        var sb = new StringBuilder();

        sb.AppendLine($"using Microsoft.EntityFrameworkCore;");
        sb.AppendLine($"using Microsoft.EntityFrameworkCore.Metadata.Builders;");

        sb.AppendLine($"using {metadata.SolutionName}.Modules.{input.Module}.Domain.Entities;");

        sb.AppendLine($"namespace {metadata.SolutionName}.Modules.{input.Module}.Domain.Entities;");
        sb.AppendLine();

        sb.AppendLine($"public class {entityName}EntityConfiguration : IEntityTypeConfiguration<{entityName}>");
        sb.AppendLine("{");

        sb.AppendLine($"    public void Configure(EntityTypeBuilder<{entityName}> builder)");
        sb.AppendLine("    {");

        foreach (var fieldDto in fieldsDtos)
        {
            var fieldNameAsPascalCase = StringExtensions.ToPascalCase(fieldDto.FieldName);

            sb.AppendLine($"        builder.Property(t => t.{fieldNameAsPascalCase})");

            if (fieldDto.IsNullable is false)
            {
                sb.AppendLine("            .IsRequired()");
            }

            if (fieldDto.MaxLength > 0)
            {
                sb.AppendLine($"            .HasMaxLength({fieldDto.MaxLength})");
            }

            sb.AppendLine("            ;");

            sb.AppendLine();
        }

        sb.AppendLine("}");
        sb.AppendLine("}");

        var content = sb.ToString();

        return content;
    }

}