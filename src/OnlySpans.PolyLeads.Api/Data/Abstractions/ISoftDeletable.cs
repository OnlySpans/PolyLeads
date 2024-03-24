namespace OnlySpans.PolyLeads.Api.Data.Abstractions;

public interface ISoftDeletable
{
    DateTime? DeletedAt { get; }

    Guid? DeletedBy { get; }
}
