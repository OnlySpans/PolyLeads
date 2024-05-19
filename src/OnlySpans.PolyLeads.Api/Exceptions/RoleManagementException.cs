using System.Diagnostics;

namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class RoleManagementException : ApiException
{
    public RoleManagementException(string? message, Exception? innerException = null)
        : base(message, innerException) { }

    [StackTraceHidden]
    public static void ThrowIfNotExist(string roleName)
    {
        var allRoles = new[] {"Student", "StudentUnionOrganizer", "Headman", "Admin"};

        if (!allRoles.Contains(roleName))
            throw new RoleManagementException($"Роли с названием {roleName} не существует");
    }
}