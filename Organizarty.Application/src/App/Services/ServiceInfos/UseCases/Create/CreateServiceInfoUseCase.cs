using FluentValidation;
using Organizarty.Application.App.ServiceInfos.Data;
using Organizarty.Application.App.ServiceInfos.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.ServiceInfos.UseCases;

public class CreateServiceInfoUseCase
{
    private readonly IServiceInfoRepository _serviceInfoRepository;
    private readonly IValidator<ServiceInfo> _serviceValidator;

    public CreateServiceInfoUseCase(IServiceInfoRepository serviceInfoRepository, IValidator<ServiceInfo> serviceValidator)
    {
        _serviceInfoRepository = serviceInfoRepository;
        _serviceValidator = serviceValidator;
    }

    public async Task Execute(CreateserviceInfoDto serviceinfoDto)
    {
        var service = serviceinfoDto.ToModel;
        ValidationUtils.Validate(_serviceValidator, service, "Invalid Service");

        await _serviceInfoRepository.Create(service);
    }
}
