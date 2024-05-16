using OnlySpans.PolyLeads.Api.Data.Entities;

namespace OnlySpans.PolyLeads.Api.Data.Abstractions.Entities;

public interface ISoftDeletable
{
    Guid? DeletedById { get; set; }

    DateTime? DeletedAt { get; set; }

    ApplicationUser? DeletedBy { get; set; }
}
