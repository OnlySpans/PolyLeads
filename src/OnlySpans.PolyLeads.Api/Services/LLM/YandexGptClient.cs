using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using OnlySpans.PolyLeads.Api.Abstractions.LLM;
using OnlySpans.PolyLeads.Api.Data.Options;
using OnlySpans.PolyLeads.Api.Data.Records.LLM;

namespace OnlySpans.PolyLeads.Api.Services.LLM;

public sealed class YandexGptClient : ILLMClient
{
    private readonly HttpClient _httpClient;
    
    private readonly IOptions<LLMOptions> _options;

    public YandexGptClient(
        HttpClient httpClient, 
        IOptions<LLMOptions> options)
    {
        _httpClient = httpClient;
        _options = options;
    }

    public async Task<Stream> GenerateResponseAsync(
        string userPrompt, 
        string documents,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var values = _options.Value;
        
        var requestBody = new YandexGptRequestBody
        {
            ModelUri = $"gpt://{values.FolderId}/{values.ModelId}",
            CompletionOptions = new()
            {
                Stream = true,
                Temperature = values.Temperature,
                MaxTokens = values.MaxResponseTokens
            },
            Messages = [
                new()
                {
                    Role = "system",
                    Text = values.SystemPrompt
                },
                new()
                {
                    Role = "user",
                    Text = $"Вопрос пользователя: {userPrompt}. Документы: {documents}"
                }
            ]
        };

        var request = new HttpRequestMessage(HttpMethod.Post, values.RequestUri)
        {
            Content = JsonContent.Create(requestBody)
        };

        request.Headers.Authorization = new AuthenticationHeaderValue(
            "Api-Key", 
            values.ApiKey);

        var response = await _httpClient.SendAsync(request, cancellationToken);

        var body = await response
            .Content
            .ReadAsStreamAsync(cancellationToken);

        return body;
    }
}