using Organizarty.Application.App.Schedules.Entities;

namespace Organizarty.Application.App.Schedules.Data;

public interface IServiceOrderRepository
{
    Task<ServiceOrder> Add(ServiceOrder service);
    Task<ServiceOrder> Update(ServiceOrder service);

    Task<List<ServiceOrder>> ListFromThirdParty(string thirdPartyId);
    Task<List<ServiceOrder>> ListFromShedule(string scheduleid);
    Task<ServiceOrder?> FindById(string id);
}
