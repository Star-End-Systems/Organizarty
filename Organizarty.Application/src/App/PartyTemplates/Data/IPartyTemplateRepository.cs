using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IPartyTemplateRepository
{
    Task<PartyTemplate> Create(PartyTemplate party);
    Task<PartyTemplate?> FromId(Guid partyId);
    Task<PartyTemplate?> FromIdWithLocation(Guid partyId);

    Task<List<PartyTemplate>> FromUser(Guid userId);
}
