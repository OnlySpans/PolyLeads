using Mapster;
using MapsterMapper;

namespace OnlySpans.PolyLeads.Api.Startup;

public static class MapperExtensions
{
    public static WebApplicationBuilder AddMapper(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddSingleton(_ =>
        {
            var config = new TypeAdapterConfig();
            config.Default.PreserveReference(true);
            config.Scan(typeof(Startup).Assembly);

            return config;
        });

        services.AddSingleton<IMapper, ServiceMapper>();

        return builder;
    }
}
