using HotChocolate;
using HotChocolate.Types;

namespace OnlySpans.PolyLeads.Api.Schema.Inputs.Users.Sign.SignInKey;

[GraphQLDescription("Ключ для идентификации пользователя, может быть почтой или никнеймом")]
[UnionType("SignInKey")]
public interface ISignInKey;
