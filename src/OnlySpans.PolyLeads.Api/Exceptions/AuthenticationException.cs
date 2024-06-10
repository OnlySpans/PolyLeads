using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class AuthenticationException : ApiException
{
    public AuthenticationException(
        string displayMessage,
        string? logMessage = null,
        Exception? innerException = null) :
        base(displayMessage, logMessage, innerException) { }

    [StackTraceHidden]
    public static void ThrowIfNull<T>([NotNull] T? value, string message)
    {
        if (value is not null)
            return;

        throw new AuthenticationException(message);
    }
}