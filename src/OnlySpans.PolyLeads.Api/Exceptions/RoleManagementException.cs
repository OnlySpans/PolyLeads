namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class RoleManagementException : ApiException
{
    public RoleManagementException(
        string displayMessage,
        string? logMessage = null,
        Exception? innerException = null) :
        base(displayMessage, logMessage, innerException) { }
}