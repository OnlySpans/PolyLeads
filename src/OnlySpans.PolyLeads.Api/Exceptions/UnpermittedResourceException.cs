namespace OnlySpans.PolyLeads.Api.Exceptions;

public class UnpermittedResourceException : ApiException
{
    public UnpermittedResourceException(string message) :
        base(message) { }
}