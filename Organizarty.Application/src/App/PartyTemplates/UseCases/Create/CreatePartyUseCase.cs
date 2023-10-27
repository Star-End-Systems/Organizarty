using FluentValidation;
using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Party.UseCases;

public class CreatePartyUseCase
{
    private readonly IPartyTemplateRepository _partyRepository;
    private readonly IValidator<PartyTemplate> _partyValidator;

    public CreatePartyUseCase(IPartyTemplateRepository repository, IValidator<PartyTemplate> partyValidator)
    {
        _partyRepository = repository;
        _partyValidator = partyValidator;
    }

    public async Task Execute(CreatePartyDto partyDto)
    {
        var party = partyDto.ToModel;
        ValidationUtils.Validate(_partyValidator, party, "Validation for Party fail");

        await _partyRepository.Create(party);
    }
}
