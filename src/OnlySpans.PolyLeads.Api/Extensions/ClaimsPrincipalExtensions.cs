using System.Security.Claims;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        string? userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        AuthenticationException.ThrowIfNull(userId, "Пользователь не аутентифицирован");
        return Guid.Parse(userId);
    }
}
