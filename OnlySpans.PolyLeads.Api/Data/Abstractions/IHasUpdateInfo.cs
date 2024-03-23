namespace OnlySpans.PolyLeads.Api.Data.Abstractions;

public interface IHasUpdateInfo
{
    DateTime UpdatedAt { get; init; }

    Guid UpdatedBy { get; init; }
}
