namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class AuthenticationException : ApiException
{
    public AuthenticationException(string? message, Exception? innerException = null) : base(message, innerException) { }
}