namespace OnlySpans.PolyLeads.Api.Extensions;

public static class ApplicationUserExtensions
{
    public static string? GetFullNameOrDefault(this Entities.ApplicationUser? user)
    {
        return user is null
            ? null
            : $"{user.FirstName} {user.LastName} {user.Patronymic}".TrimEnd();
    }
}
