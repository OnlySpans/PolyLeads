using System.Diagnostics;
using System.Security.Claims;
using OnlySpans.PolyLeads.Api.Data.Abstractions.Commands;
using OnlySpans.PolyLeads.Api.Data.Records;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Pipelines;

public sealed class CalledByUserPipeline<TRequest, TResponse>(IHttpContextAccessor contextAccessor) : 
    IPipelineBehavior<TRequest, TResponse> 
        where TRequest : ICalledByUser, IMessage
{
    public ValueTask<TResponse> Handle(
        TRequest message,
        CancellationToken cancellationToken,
        MessageHandlerDelegate<TRequest, TResponse> next)
    {
        if (message.User.WasSet)
            return next(message, cancellationToken);

        var context = contextAccessor.HttpContext;

        if (context is null)
            throw new UnreachableException("HttpContext is null");

        var id = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        AuthorizationException.ThrowIfNull(id, "У пользователя отсутствует клейм с id");

        var guid = Guid.Parse(id);
        message.User = new Identity(guid);
        return next(message, cancellationToken);
    }
}