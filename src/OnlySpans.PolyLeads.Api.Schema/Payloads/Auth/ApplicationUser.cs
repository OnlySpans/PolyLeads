namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Auth;

[GraphQLDescription("Пользователь")]
public sealed record ApplicationUser
{
    [GraphQLDescription("Имя пользователя")]
    public string FirstName { get; init; } = string.Empty;

    [GraphQLDescription("Фамилия пользователя")]
    public string LastName { get; init; } = string.Empty;

    [GraphQLDescription("Отчество")]
    public string? Patronymic { get; init; }
    
    [GraphQLDescription("Логин пользователя")]
    public string UserName { get; init; } = string.Empty;
}