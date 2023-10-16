using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IServiceGroupRepository
{
    Task<ServiceGroup> Add(ServiceGroup group);
    Task<List<ServiceGroup>> ListFoodFromParty(Guid partyId);
}
