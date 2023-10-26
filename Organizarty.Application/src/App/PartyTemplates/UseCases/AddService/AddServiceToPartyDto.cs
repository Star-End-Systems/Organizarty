using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.UseCases;

public record AddServiceToPartyDto(Guid serviceInfoId, Guid partyTemplateId, string? note)
{
    public ServiceGroup ToModel
    => new ServiceGroup
    {
        Note = note ?? "",
        ServiceInfoId = serviceInfoId,
        PartyTemplateId = partyTemplateId
    };
}
