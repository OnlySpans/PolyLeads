using System.ComponentModel;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OnlySpans.PolyLeads.Api.Swagger.Filters;

public class SchemaMembersDescriptorFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.MemberInfo is null) return;

        var descriptionAttributeType = typeof(DescriptionAttribute);

        if (context
            .MemberInfo
            .GetCustomAttributes(descriptionAttributeType, true)
            .FirstOrDefault() is not DescriptionAttribute descriptionAttribute)
            return;

        schema.Description = descriptionAttribute.Description;
    }
}
