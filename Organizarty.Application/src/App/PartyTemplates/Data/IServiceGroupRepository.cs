using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IServiceGroupRepository
{
    Task<ServiceGroup> Add(ServiceGroup group);
    Task<ServiceGroup> Update(ServiceGroup group);
    Task Delete(string id);
    Task<List<ServiceGroup>> ListFromParty(string partyId);

    Task<ServiceGroup?> FindById(string id);
}
