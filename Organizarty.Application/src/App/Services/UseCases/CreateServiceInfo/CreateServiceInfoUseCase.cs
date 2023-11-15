using FluentValidation;
using Organizarty.Application.App.Services.Data;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Services.UseCases;

public class CreateServiceInfoUseCase
{
    private readonly IServiceInfoRepository _serviceInfoRepository;
    private readonly IValidator<ServiceInfo> _serviceValidator;

    public CreateServiceInfoUseCase(IServiceInfoRepository serviceInfoRepository, IValidator<ServiceInfo> serviceValidator)
    {
        _serviceInfoRepository = serviceInfoRepository;
        _serviceValidator = serviceValidator;
    }

    public async Task<ServiceInfo> Execute(CreateserviceInfoDto serviceinfoDto)
    {
        var service = serviceinfoDto.ToModel;
        ValidationUtils.Validate(_serviceValidator, service, "Invalid Service");

        return await _serviceInfoRepository.Create(service);
    }
}
