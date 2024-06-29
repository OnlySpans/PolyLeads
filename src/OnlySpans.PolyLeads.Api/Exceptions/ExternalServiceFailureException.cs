namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class ExternalServiceFailureException : ApiException
{
    public ExternalServiceFailureException(string message)
        : base(message) { }
}