using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class ResourceNotFoundException : ApiException
{
    public ResourceNotFoundException(
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

        throw new ResourceNotFoundException(displayMessage, logMessage, innerException);
    }

    [StackTraceHidden]
    public static void ThrowIfNull<T>([NotNull] T? value, string message)
    {
        if (value is not null) return;

        throw new ResourceNotFoundException(message);
    }
}