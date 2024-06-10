using System.Diagnostics;

namespace OnlySpans.PolyLeads.Api.Exceptions;

public class UnpermittedResourceException : ApiException
{
    public UnpermittedResourceException(
        string displayMessage,
        string? logMessage = null,
        Exception? innerException = null) :
        base(displayMessage, logMessage, innerException) { }

    [StackTraceHidden]
    public static void ThrowIf(
        bool condition,
        string displayMessage,
        string logMessage,
        Exception? innerException = null)
    {
        if (!condition) return;

        throw new UnpermittedResourceException(displayMessage, logMessage, innerException);
    }
}