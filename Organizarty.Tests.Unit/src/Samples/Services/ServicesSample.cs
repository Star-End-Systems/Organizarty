using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Services.UseCases;
using Organizarty.Tests.Mock.UseCases;

namespace Organizarty.Tests.Unit.Samples.Services;

public static class ServicesSample
{
    public static async Task<ServiceType> SetupServiceType(CreateServiceTypeUseCase createService, Guid thirdPartyId)
    {
        var data = new CreateServiceTypeDto("Fotografo", "Um ótimo serviço de Fotografos", thirdPartyId, new());

        return await createService.Execute(data);
    }

    public static async Task<ServiceType> SetupServiceType(UseCasesFactory usecases, Guid thirdPartyId)
    {
        var use = usecases.CreateServiceTypeUseCase();

        return await SetupServiceType(use, thirdPartyId);
    }

    public static async Task<ServiceInfo> SetupServiceInfo(CreateServiceInfoUseCase createService, Guid ServiceTypeId)
    {
        var data = new CreateserviceInfoDto(60m, true, "500 fotos", new(), ServiceTypeId);

        return await createService.Execute(data);
    }

    public static async Task<ServiceInfo> SetupServiceInfo(UseCasesFactory usecases, Guid serviceTypeId)
    {
        var use = usecases.CreateServiceInfoUseCase();

        return await SetupServiceInfo(use, serviceTypeId);
    }
}
