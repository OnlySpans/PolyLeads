using OnlySpans.PolyLeads.Api.Data.Records;

namespace OnlySpans.PolyLeads.Api.Data.Abstractions.Commands;

public interface ICalledByUser
{
    MaybeSet<Identity?> User { get; set; }
}