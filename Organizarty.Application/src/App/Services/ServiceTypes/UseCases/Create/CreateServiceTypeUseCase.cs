using FluentValidation;
using Organizarty.Application.App.Services.Data;
using Organizarty.Application.App.ServiceTypes.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.ServiceTypes.UseCases;

public class CreateServiceTypeUseCase
{
    private readonly IServiceTypeRepository _serviceTypeRepository;
    private readonly IValidator<ServiceType> _serviceValidator;

    public CreateServiceTypeUseCase(IServiceTypeRepository serviceTypeRepository, IValidator<ServiceType> serviceValidator)
    {
        _serviceTypeRepository = serviceTypeRepository;
        _serviceValidator = serviceValidator;
    }

    public async Task Execute(CreateServiceTypeDto serviceDto)
    {
        var service = serviceDto.ToModel;
        ValidationUtils.Validate(_serviceValidator, service, "Invalid Service");

        await _serviceTypeRepository.Create(service);
    }
}
