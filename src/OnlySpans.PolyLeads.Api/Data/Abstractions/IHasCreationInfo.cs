namespace OnlySpans.PolyLeads.Api.Data.Abstractions;

public interface IHasCreationInfo
{
    DateTime CreatedAt { get; }

    Guid CreatedBy { get; }
}
