using JetBrains.Annotations;
using Mapster;
using OnlySpans.PolyLeads.Api.Data.Entities;

namespace OnlySpans.PolyLeads.Api.Data.Mappings.Dtos;

using Dto = Dto.Data;

[UsedImplicitly]
public class DetailedDocumentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .ForType<Document, Dto.DetailedDocument>()
            .IgnoreNullValues(true)
            .Map(x => x.CreatedByUser, x => $"{x.CreatedBy.FirstName} {x.CreatedBy.LastName}")
            .Map(x => x.UpdatedByUser, x => GetFullName(x.UpdatedBy))
            .Map(x => x.DeletedByUser, x => GetFullName(x.DeletedBy));
    }

    // fuck it
    private static string? GetFullName(ApplicationUser? user)
    {
        return user is null
            ? null
            : $"{user.FirstName} {user.LastName}";
    }
}
