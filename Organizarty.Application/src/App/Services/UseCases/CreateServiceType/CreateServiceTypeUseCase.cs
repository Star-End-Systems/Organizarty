using FluentValidation;
using Organizarty.Application.App.Services.Data;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Services.UseCases;

public class CreateServiceTypeUseCase
{
    private readonly IServiceTypeRepository _serviceTypeRepository;
    private readonly IValidator<ServiceType> _serviceValidator;

    public CreateServiceTypeUseCase(IServiceTypeRepository serviceTypeRepository, IValidator<ServiceType> serviceValidator)
    {
        _serviceTypeRepository = serviceTypeRepository;
        _serviceValidator = serviceValidator;
    }

    public async Task<ServiceType> Execute(CreateServiceTypeDto serviceDto)
    {
        var service = serviceDto.ToModel;
        ValidationUtils.Validate(_serviceValidator, service, "Invalid Service");

        return await _serviceTypeRepository.Create(service);
    }
}
