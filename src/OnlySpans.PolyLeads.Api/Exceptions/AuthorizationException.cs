namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class AuthorizationException : ApiException
{
    public AuthorizationException(string? message, Exception? innerException = null) : base(message, innerException) { }
}