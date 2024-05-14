using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using OnlySpans.PolyLeads.Api.Swagger.Filters;

namespace OnlySpans.PolyLeads.Api.Startup;

public static class SwaggerExtensions
{
    public static WebApplication UseDevelopmentConfiguration(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return app;

        app.UseWhen(x => !x.Request.Path.StartsWithSegments("/api"), builder =>
        {
            builder.UseDeveloperExceptionPage();
        });

        const string swaggerPrefix = "api";

        app.UseSwagger(options =>
        {
            options.RouteTemplate = $"{swaggerPrefix}/{{documentName}}/swagger.json";
        });
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = $"{swaggerPrefix}";
            c.SwaggerEndpoint($"/{swaggerPrefix}/v1/swagger.json", $"{nameof(Api)} v1");
        });

        return app;
    }

    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            var name = Assembly.GetExecutingAssembly().GetName().Name!;
            options.SwaggerDoc("v1", new OpenApiInfo { Title = name, Version = "v1" });

            options.SchemaFilter<SchemaMembersDescriptorFilter>();
            options.SchemaFilter<SchemaDescriptorFilter>();
            options.SchemaFilter<EnumDescriptorFilter>();

            options.EnableAnnotations();

            // add XML comments reader
            var filePath = Path.Combine(AppContext.BaseDirectory, $"{name}.xml");
            if (File.Exists(filePath))
                options.IncludeXmlComments(filePath);

            options.MapType<TimeSpan>(() => new OpenApiSchema
            {
                Type = "string",
                Example = new OpenApiString("00:00:00")
            });
        });

        return builder;
    }
}
