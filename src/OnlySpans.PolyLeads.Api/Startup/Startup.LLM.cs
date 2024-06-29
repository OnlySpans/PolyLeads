using OnlySpans.PolyLeads.Api.Abstractions.LLM;
using OnlySpans.PolyLeads.Api.Services.LLM;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddLLMIntegration(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddScoped<ILLMClient, YandexGptClient>();

        return builder;
    }
}