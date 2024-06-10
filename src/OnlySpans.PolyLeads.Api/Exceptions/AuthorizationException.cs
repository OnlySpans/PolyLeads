using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class AuthorizationException : ApiException
{
    public AuthorizationException(string displayMessage, string? logMessage = null) :
        base(displayMessage, logMessage) { }

    [StackTraceHidden]
    public static void ThrowIfNull<T>([NotNull] T? value, string message)
    {
        if (value is not null)
            return;

        throw new AuthorizationException(message);
    }
}