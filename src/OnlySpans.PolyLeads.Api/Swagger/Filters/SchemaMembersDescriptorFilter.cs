using System.ComponentModel;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OnlySpans.PolyLeads.Api.Swagger.Filters;

public class SchemaMembersDescriptorFilter : ISchemaFilter
{
    private static Type DescriptionAttributeType { get; } = typeof(DescriptionAttribute);

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.MemberInfo is null) return;

        if (context
            .MemberInfo
            .GetCustomAttributes(DescriptionAttributeType, true)
            .FirstOrDefault() is not DescriptionAttribute descriptionAttribute)
            return;

        schema.Description = descriptionAttribute.Description;
    }
}
