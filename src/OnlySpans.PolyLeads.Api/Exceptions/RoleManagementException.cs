namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class RoleManagementException : ApiException
{
    public RoleManagementException(string message) :
        base(message) { }
}