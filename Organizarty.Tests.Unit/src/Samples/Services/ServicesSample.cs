using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Services.Enums;
using Organizarty.Application.App.Services.UseCases;
using Organizarty.Tests.Mock.UseCases;

namespace Organizarty.Tests.Unit.Samples.Services;

public static class ServicesSample
{
    public static async Task<ServiceType> SetupServiceType(CreateServiceTypeUseCase createService, string thirdPartyId)
    {
        var data = new CreateServiceTypeDto("Fotografo", "Um ótimo serviço de Fotografos", ServiceCategory.Fotografo, thirdPartyId, new());

        return await createService.Execute(data);
    }

    public static async Task<ServiceType> SetupServiceType(UseCasesFactory usecases, string thirdPartyId)
    {
        var use = usecases.CreateServiceTypeUseCase();

        return await SetupServiceType(use, thirdPartyId);
    }

    public static async Task<ServiceInfo> SetupServiceInfo(CreateServiceInfoUseCase createService, string ServiceTypeId)
    {
        var data = new CreateserviceInfoDto(60m, true, "500 fotos", new(), ServiceTypeId);

        return await createService.Execute(data);
    }

    public static async Task<ServiceInfo> SetupServiceInfo(UseCasesFactory usecases, string serviceTypeId)
    {
        var use = usecases.CreateServiceInfoUseCase();

        return await SetupServiceInfo(use, serviceTypeId);
    }
}
