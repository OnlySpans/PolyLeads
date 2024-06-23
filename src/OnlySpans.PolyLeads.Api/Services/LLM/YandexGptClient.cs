using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using OnlySpans.PolyLeads.Api.Abstractions.LLM;
using OnlySpans.PolyLeads.Api.Data.Options;
using OnlySpans.PolyLeads.Api.Exceptions;
using OnlySpans.PolyLeads.Api.Utils;

namespace OnlySpans.PolyLeads.Api.Services.LLM;

public sealed class YandexGptClient : ILLMClient
{
    private readonly HttpClient _httpClient;
    
    private readonly LLMOptions _options;

    public YandexGptClient(
        HttpClient httpClient, 
        IOptions<LLMOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<Stream> GenerateResponseAsync(
        string userPrompt, 
        IReadOnlyList<string> documentsContent,
        CancellationToken cancellationToken = new())
    {
        var requestBody = new YandexGptRequestBody
        {
            ModelUri = $"gpt://{_options.FolderId}/{_options.ModelId}",
            CompletionOptions = new()
            {
                Stream = true,
                Temperature = _options.Temperature,
                MaxTokens = _options.MaxResponseTokens
            },
            Messages = [
                new()
                {
                    Role = MessageRole.System,
                    Text = _options.SystemPrompt
                },
                new()
                {
                    Role = MessageRole.User,
                    Text = $"Вопрос пользователя: {userPrompt}. Документы: {string.Join(". ", documentsContent)}"
                }
            ]
        };

        var request = new HttpRequestMessage(HttpMethod.Post, _options.RequestUri)
        {
            Content = JsonContent.Create(requestBody)
        };

        request.Headers.Authorization = new AuthenticationHeaderValue(
            "Api-Key", 
            _options.ApiKey);

        var response = await _httpClient.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new ExternalServiceFailureException(response.ReasonPhrase ?? "");

        return await response
            .Content
            .ReadAsStreamAsync(cancellationToken);
    }
}

file sealed record YandexGptRequestBody
{
    public string ModelUri { get; init; } = string.Empty;

    public CompletionOptions CompletionOptions { get; init; } = default!;

    public List<Message> Messages { get; init; } = default!;
}

public sealed record CompletionOptions
{
    public bool Stream { get; init; }

    public float Temperature { get; init; }

    public int MaxTokens { get; init; }
}

file sealed record Message
{
    public string Role { get; init; } = string.Empty;

    public string Text { get; init; } = string.Empty;
}