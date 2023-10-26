using Organizarty.Application.App.ServiceInfos.Entities;

namespace Organizarty.Application.App.ServiceInfos.Data;

public interface IServiceInfoRepository
{
    Task<ServiceInfo> Create(ServiceInfo service);
}
