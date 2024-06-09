namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class RoleManagementException : ApiException
{
    public RoleManagementException(string? message, Exception? innerException = null)
        : base(message, innerException) { }
}
