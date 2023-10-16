using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IDecorationGroupRepository
{
    Task<DecorationGroup> Add(DecorationGroup group);
    Task<List<DecorationGroup>> ListFoodFromParty(Guid partyId);
}
