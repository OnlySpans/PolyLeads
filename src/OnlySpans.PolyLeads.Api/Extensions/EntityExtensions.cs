using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Abstractions.Entities;

namespace OnlySpans.PolyLeads.Api.Extensions;

public static class EntityExtensions
{
    public static IQueryable<TEntity> IncludeAuditProperties<TEntity>(this IQueryable<TEntity> query)
        where TEntity : class,
            IEntity,
            IHasCreationInfo,
            IHasUpdateInfo,
            ISoftDeletable
    {
        return query
           .Include(x => x.CreatedBy)
           .Include(x => x.UpdatedBy)
           .Include(x => x.DeletedBy);
    }

    public static IQueryable<TEntity> WhereIsNotDeleted<TEntity>(this IQueryable<TEntity> query)
        where TEntity : class,
            ISoftDeletable
    {
        return query
           .Where(x => x.DeletedAt == null);
    }
}
