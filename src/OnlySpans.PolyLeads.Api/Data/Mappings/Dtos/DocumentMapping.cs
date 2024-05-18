using JetBrains.Annotations;
using Mapster;
using OnlySpans.PolyLeads.Api.Extensions;

namespace OnlySpans.PolyLeads.Api.Data.Mappings.Dtos;

using Dto = Dto.Documents;

[UsedImplicitly]
public sealed class DocumentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
           .ForType<Entities.Document, Dto.Document>()
           .Map(x => x.CreatedBy, x => x.CreatedBy.GetFullNameOrDefault())
           .Map(x => x.Resource, x => x.Source.Description)
           .Map(x => x.FileRecognitionStatus, x => x.RecognitionStatus);
    }
}
