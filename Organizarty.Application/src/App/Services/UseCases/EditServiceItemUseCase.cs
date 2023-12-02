using FluentValidation;
using Organizarty.Application.App.Services.Data;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.Exceptions;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Services.UseCases;

public class EditServiceItemUseCase
{
    public record UpdateDto(Guid id, string name, string description, List<string> tags);

    private readonly IServiceTypeRepository _serviceTypeRepository;
    private readonly IValidator<ServiceType> _serviceValidator;

    public EditServiceItemUseCase(IServiceTypeRepository serviceTypeRepository, IValidator<ServiceType> serviceValidator)
    {
        _serviceTypeRepository = serviceTypeRepository;
        _serviceValidator = serviceValidator;
    }

    public async Task<ServiceType> Execute(UpdateDto serviceDto)
    {
        var service = await _serviceTypeRepository.FindById(serviceDto.id) ?? throw new NotFoundException("Service not found");

        service.Name = serviceDto.name;
        service.Description = serviceDto.description;
        service.Tags = serviceDto.tags;

        ValidationUtils.Validate(_serviceValidator, service, "Invalid Service");

        return await _serviceTypeRepository.Update(service);
    }
}
