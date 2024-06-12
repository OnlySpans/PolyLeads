using System.Diagnostics;
using OnlySpans.PolyLeads.Api.Data.Abstractions.Commands;
using OnlySpans.PolyLeads.Api.Data.Records;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Extensions;

public static class CalledByUserExtensions
{
    public static Identity GetUser(this ICalledByUser command)
    {
        if (!command.User.WasSet)
            throw new UnreachableException("Пользователь не аутентифицирован");

        if (command.User.Value is null)
            throw new AuthenticationException("Пользователь не аутентифицирован");

        return command.User.Value;
    }
}