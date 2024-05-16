using OnlySpans.PolyLeads.Api.Data.Entities;

namespace OnlySpans.PolyLeads.Api.Data.Abstractions.Entities;

public interface IHasUpdateInfo
{
    Guid? UpdatedById { get; set; }

    DateTime? UpdatedAt { get; set; }

    ApplicationUser? UpdatedBy { get; set; }
}
