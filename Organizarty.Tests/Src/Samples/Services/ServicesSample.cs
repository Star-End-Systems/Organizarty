using Organizarty.Application.App.ServiceInfos.Entities;
using Organizarty.Application.App.ServiceInfos.UseCases;
using Organizarty.Application.App.ServiceTypes.Entities;
using Organizarty.Application.App.ServiceTypes.UseCases;

namespace Organizarty.Tests.Samples.Services;

public static class ServicesSample
{
    public static async Task<ServiceType> SetupServiceType(CreateServiceTypeUseCase createService, Guid thirdPartyId)
    {
        var data = new CreateServiceTypeDto("Fotografo", "Um ótimo serviço de Fotografos", thirdPartyId);

        return await createService.Execute(data);
    }

    public static async Task<ServiceInfo> SetupServiceInfo(CreateServiceInfoUseCase createService, Guid ServiceTypeId)
    {
        var data = new CreateserviceInfoDto(60m,true, "500 fotos", new(), ServiceTypeId);

        return await createService.Execute(data);
    }
}
