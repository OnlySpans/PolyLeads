using HotChocolate;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Services.Logging;

public sealed class GenericErrorFilter : IErrorFilter
{
    private ILogger<GenericErrorFilter> Logger { get; init; }

    public GenericErrorFilter(ILogger<GenericErrorFilter> logger)
    {
        Logger = logger;
    }

    public IError OnError(IError error)
    {
        Logger.LogError(
            error.Exception,
            "{Message}",
            error.Message);

        if (error.Exception is not ApiException exception)
            return error;

        return BuildKnownError(error, exception);
    }

    private static IError BuildKnownError(IError error, ApiException ex) =>
        error
           .WithMessage(ex.Message)
           .WithCode(ExceptionToStatusCode(ex));

    private static string ExceptionToStatusCode(ApiException ex) =>
        ex switch
        {
            AuthenticationException => "UNAUTHORIZED",
            _                       => "INTERNAL_SERVER_ERROR",
        };
}