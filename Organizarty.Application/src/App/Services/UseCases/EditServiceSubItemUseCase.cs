using FluentValidation;
using Organizarty.Application.App.Services.Data;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.Exceptions;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Services.UseCases;

public class EditServiceSubItemUseCase
{
    public record UpdateDto(Guid Id, decimal Price, bool IsAvaiable, string Plan, List<string> Images);

    private readonly IServiceInfoRepository _serviceRepository;
    private readonly IValidator<ServiceInfo> _serviceValidator;

    public EditServiceSubItemUseCase(IValidator<ServiceInfo> serviceValidator, IServiceInfoRepository serviceRepository)
    {
        _serviceValidator = serviceValidator;
        _serviceRepository = serviceRepository;
    }

    public async Task<ServiceInfo> Execute(UpdateDto serviceDto)
    {
        var service = await _serviceRepository.FindById(serviceDto.Id) ?? throw new NotFoundException("Service not found");

        service.Price = serviceDto.Price;
        service.Plan = serviceDto.Plan;
        service.IsAvaible = serviceDto.IsAvaiable;
        service.Images = serviceDto.Images;

        ValidationUtils.Validate(_serviceValidator, service, "Invalid Service");

        return await _serviceRepository.Update(service);
    }
}
