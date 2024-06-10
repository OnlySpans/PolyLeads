namespace OnlySpans.PolyLeads.Api.Exceptions;

public abstract class ApiException : Exception
{
    public string DisplayMessage { get; init; }

    protected ApiException(
        string displayMessage,
        string? logMessage = null,
        Exception? innerException = null) : base(logMessage ?? displayMessage, innerException) =>
        DisplayMessage = displayMessage;
}