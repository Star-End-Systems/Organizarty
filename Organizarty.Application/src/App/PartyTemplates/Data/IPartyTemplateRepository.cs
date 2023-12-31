using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IPartyTemplateRepository
{
    Task<PartyTemplate> Create(PartyTemplate party);
    Task<PartyTemplate> Update(PartyTemplate party);
    Task<PartyTemplate?> FindById(string partyId);
    Task<PartyTemplate?> FromIdWithLocation(string partyId);

    Task<List<PartyTemplate>> FromUser(string userId);
}
