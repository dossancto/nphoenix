namespace PhoenixTool.App.Generate.Commum.Dtos;

public record FieldTypeDefinition
(
    string FieldName,
    string TypeName,
    bool IsNullable,
    int MaxLength
)
{
  public static FieldTypeDefinition FromRawString(string raw)
  {
    var tokens = raw.Split(":");

    if (tokens.Length < 2)
    {
      throw new ArgumentException("Invalid raw string");
    }

    var fieldName = tokens[0];
    var typeName = tokens[1];
    var isNullable = false;
    var maxLenghtParam = tokens.ElementAtOrDefault(2);

    var maxLength = 0;

    if (maxLenghtParam is not null)
    {
      if (!int.TryParse(maxLenghtParam, out var maxLengthParsed))
      {
        throw new ArgumentException("Invalid max length, should be a number");
      }

      maxLength = maxLengthParsed;
    }

    if (typeName.EndsWith('?'))
    {
      typeName = typeName.Remove(typeName.Length - 1);
      isNullable = true;
    }

    return new(
        fieldName,
        typeName,
        isNullable,
        maxLength
    );
  }
}
