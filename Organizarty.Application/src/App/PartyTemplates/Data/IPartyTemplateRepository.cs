using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IPartyTemplateRepository
{
    Task<PartyTemplate> Create(PartyTemplate party);
    Task<PartyTemplate?> FromId(Guid partyId);
}
