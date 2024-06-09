using System.ComponentModel;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OnlySpans.PolyLeads.Api.Swagger.Filters;

public class EnumDescriptorFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!CanHandle(schema, context)) return;

        var builder = new StringBuilder(schema.Description);

        var enumType = context.Type;

        var enumValues = enumType
            .GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);


        var enumValueType = Enum.GetUnderlyingType(enumType);
        builder.Append("<p>Members :</p><ul>");

        var descriptionAttributeType = typeof(DescriptionAttribute);

        foreach (var enumValue in enumValues)
        {
            var enumDescription = enumValue
               .GetCustomAttributes(descriptionAttributeType, true)
               .FirstOrDefault() is DescriptionAttribute descriptionAttribute
                ? $"{descriptionAttribute.Description} ({enumValue.Name})"
                : enumValue.Name;

            builder.Append($"<li>{Convert.ChangeType(enumValue.GetValue(null), enumValueType)} - {(enumDescription)}</li>");
        }


        builder.Append("</ul>");


        schema.Description = builder.ToString();
    }

    private static bool CanHandle(OpenApiSchema schema, SchemaFilterContext context) =>
        schema.Enum is not null
        && schema.Enum.Any()
        && context.Type is not null
        && context.Type.IsEnum;
}
