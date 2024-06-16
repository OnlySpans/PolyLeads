using OnlySpans.PolyLeads.Api.Services.Exceptions;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddExceptionHandling(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddExceptionHandler<GlobalExceptionHandler>();

        builder
           .Services
           .AddProblemDetails();

        return builder;
    }
}