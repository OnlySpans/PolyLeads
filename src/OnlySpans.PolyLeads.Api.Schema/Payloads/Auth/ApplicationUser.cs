namespace OnlySpans.PolyLeads.Api.Schema.Payloads.Auth;

[GraphQLDescription("Пользователь")]
public sealed record ApplicationUser
{
    [GraphQLDescription("Имя")]
    public string FirstName { get; init; } = string.Empty;

    [GraphQLDescription("Фамилия")]
    public string LastName { get; init; } = string.Empty;

    [GraphQLDescription("Отчество")]
    public string? Patronymic { get; init; }
    
    [GraphQLDescription("Логин")]
    public string UserName { get; init; } = string.Empty;
}