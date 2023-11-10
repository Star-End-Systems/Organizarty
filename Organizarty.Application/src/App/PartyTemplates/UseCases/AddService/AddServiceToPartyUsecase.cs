using FluentValidation;
using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Party.UseCases;

public class AddServiceToPartyUsecase
{
    private readonly IServiceGroupRepository _serviceRepository;
    private readonly IValidator<ServiceGroup> _validator;

    public AddServiceToPartyUsecase(IServiceGroupRepository serviceRepository, IValidator<ServiceGroup> validator)
    {
        _serviceRepository = serviceRepository;
        _validator = validator;
    }

    public async Task<ServiceGroup> Execute(AddServiceToPartyDto serviceDto)
    {
        var service = serviceDto.ToModel;
        ValidationUtils.Validate(_validator, service, "Fail to add service to party.");

        return await _serviceRepository.Add(service);
    }
}
