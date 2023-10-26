using Organizarty.Application.App.ServiceTypes.Entities;

namespace Organizarty.Application.App.Services.Data;

public interface IServiceTypeRepository
{
    Task<ServiceType> Create(ServiceType service);
}
