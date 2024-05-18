using JetBrains.Annotations;
using Mapster;
using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Data.Mappings.Dtos;

using Dto = Dto.Documents;

[UsedImplicitly]
public class DetailedDocumentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .ForType<Entities.Document, Dto.DetailedDocument>()
            .IgnoreNullValues(true)
            .Map(x => x.CreatedByUser, x => x.CreatedBy.GetFullNameOrDefault())
            .Map(x => x.UpdatedByUser, x => x.UpdatedBy.GetFullNameOrDefault())
            .Map(x => x.DeletedByUser, x => x.DeletedBy.GetFullNameOrDefault())
            .Map(x => x.Source, x => x.Source.Description);
    }
}
