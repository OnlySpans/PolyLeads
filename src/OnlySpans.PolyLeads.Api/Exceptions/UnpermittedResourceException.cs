using System.Diagnostics;

namespace OnlySpans.PolyLeads.Api.Exceptions;

public class UnpermittedResourceException : ApiException
{
    public UnpermittedResourceException(string? message, Exception? innerException = null) : base(message, innerException) { }

    [StackTraceHidden]
    public static void ThrowIf(bool condition, string message, Exception? innerException = null)
    {
        if (!condition) return;

        throw new UnpermittedResourceException(message, innerException);
    }
}
