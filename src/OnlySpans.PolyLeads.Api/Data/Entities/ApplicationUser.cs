using Microsoft.AspNetCore.Identity;

namespace OnlySpans.PolyLeads.Api.Data.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string? Patronymic { get; set; }
}