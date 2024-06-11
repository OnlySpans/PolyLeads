namespace OnlySpans.PolyLeads.Api.Exceptions;

public abstract class ApiException : Exception
{
    public string DisplayMessage { get; init; }

    protected ApiException(string message) : base(message) =>
        DisplayMessage = message;
}