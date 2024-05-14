using OnlySpans.PolyLeads.Api.Data.Entities;

namespace OnlySpans.PolyLeads.Api.Data.Abstractions.Entities;

public interface IHasCreationInfo
{
    Guid CreatedById { get; set; }

    DateTime CreatedAt { get; set; }

    ApplicationUser CreatedBy { get; set; }
}
