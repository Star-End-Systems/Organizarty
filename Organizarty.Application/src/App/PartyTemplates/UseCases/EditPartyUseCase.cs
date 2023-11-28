using FluentValidation;
using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.Exceptions;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Party.UseCases;

public record EditItemDto(Guid id, string note);
public record EditItemWithQuantityDto(Guid id, int quantity, string note);

public record EditPartyDto(Guid id, string name, int expectedGuests, Guid LocationId);

public class EditPartyUseCase
{
    private readonly IPartyTemplateRepository _partyRepository;
    private readonly IDecorationGroupRepository _decorationRepository;
    private readonly IFoodGroupRepository _foodRepository;
    private readonly IServiceGroupRepository _serviceRepository;

    private readonly IValidator<FoodGroup> _foodValidator;
    private readonly IValidator<DecorationGroup> _decorationValidator;
    private readonly IValidator<ServiceGroup> _serviceValidator;
    private readonly IValidator<PartyTemplate> _partyValidator;

    public EditPartyUseCase(IPartyTemplateRepository partyRepository, IDecorationGroupRepository decorationRepository, IFoodGroupRepository foodRepository, IServiceGroupRepository serviceRepository, IValidator<FoodGroup> foodValidator, IValidator<DecorationGroup> decorationValidator, IValidator<ServiceGroup> serviceValidator, IValidator<PartyTemplate> partyValidator)
    {
        _partyRepository = partyRepository;
        _decorationRepository = decorationRepository;
        _foodRepository = foodRepository;
        _serviceRepository = serviceRepository;

        _foodValidator = foodValidator;
        _decorationValidator = decorationValidator;
        _serviceValidator = serviceValidator;
        _partyValidator = partyValidator;
    }

    public async Task<PartyTemplate> EditParty(EditPartyDto partyDto)
    {
        var party = await _partyRepository.FindById(partyDto.id) ?? throw new NotFoundException("Party not found");

        party.Name = partyDto.name;
        party.ExpectedGuests = partyDto.expectedGuests;
        party.LocationId = partyDto.LocationId;

        ValidationUtils.Validate(_partyValidator, party, "Validation for food fail");

        return await _partyRepository.Update(party);
    }

    public async Task<FoodGroup> EditFood(EditItemWithQuantityDto itemDto)
    {
        var food = await _foodRepository.FindById(itemDto.id) ?? throw new NotFoundException("Food not found");

        food.Note = itemDto.note;
        food.Quantity = itemDto.quantity;

        ValidationUtils.Validate(_foodValidator, food, "Validation for food fail");

        return await _foodRepository.Update(food);
    }

    public async Task<DecorationGroup> EditDecoration(EditItemWithQuantityDto itemDto)
    {
        var decoration = await _decorationRepository.FindById(itemDto.id) ?? throw new NotFoundException("Decoration not found");

        decoration.Note = itemDto.note;
        decoration.Quantity = itemDto.quantity;

        ValidationUtils.Validate(_decorationValidator, decoration, "Validation for decoration fail");

        return await _decorationRepository.Update(decoration);

    }

    public async Task<ServiceGroup> EditService(EditItemDto itemDto)
    {
        var service = await _serviceRepository.FindById(itemDto.id) ?? throw new NotFoundException("Service not found");

        service.Note = itemDto.note;

        ValidationUtils.Validate(_serviceValidator, service, "Validation for service fail");

        return await _serviceRepository.Update(service);
    }

}
