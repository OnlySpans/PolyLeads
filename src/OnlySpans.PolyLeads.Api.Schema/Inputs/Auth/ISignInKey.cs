using HotChocolate.Types;

namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Auth;

[GraphQLDescription("Ключ для идентификации пользователя, может быть почтой или никнеймом")]
[UnionType("SignInKey")]
public interface ISignInKey;
