using System.ComponentModel;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OnlySpans.PolyLeads.Api.Swagger.Filters;

public sealed class SchemaDescriptorFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var descriptionAttributeType = typeof(DescriptionAttribute);

        if (context
            .Type
            .GetCustomAttributes(descriptionAttributeType, true)
            .FirstOrDefault() is not DescriptionAttribute description) return;

        schema.Description = description.Description;
    }
}
