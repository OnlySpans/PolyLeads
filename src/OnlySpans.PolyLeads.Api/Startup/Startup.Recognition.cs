using OnlySpans.PolyLeads.Api.Abstractions.Recognition;
using OnlySpans.PolyLeads.Api.Services.Recognition;

namespace OnlySpans.PolyLeads.Api.Startup;

public static class RecognitionExtensions
{
    public static WebApplicationBuilder AddDocumentRecognition(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddSingleton<IDocumentRecognitionFactory, SearchableDocumentRecognitionFactory>();

        return builder;
    }
}
