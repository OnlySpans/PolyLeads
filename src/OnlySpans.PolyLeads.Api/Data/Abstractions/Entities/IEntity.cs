namespace OnlySpans.PolyLeads.Api.Data.Abstractions.Entities;

public interface IEntity;

public interface IEntity<TId> : IEntity
{
    public TId Id { get; set; }
}
