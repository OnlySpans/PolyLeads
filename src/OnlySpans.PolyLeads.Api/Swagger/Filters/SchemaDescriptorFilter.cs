using System.ComponentModel;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OnlySpans.PolyLeads.Api.Swagger.Filters;

public class SchemaDescriptorFilter : ISchemaFilter
{
    private static Type DescriptionAttributeType { get; } = typeof(DescriptionAttribute);

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context
            .Type
            .GetCustomAttributes(DescriptionAttributeType, true)
            .FirstOrDefault() is not DescriptionAttribute description) return;

        schema.Description = description.Description;
    }
}
