using FluentValidation;
using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Party.UseCases;

public class AddDecorationToPartyUseCase
{
    private readonly IDecorationGroupRepository _decorationRepository;
    private readonly IValidator<DecorationGroup> _validator;

    public AddDecorationToPartyUseCase(IDecorationGroupRepository foodRepository, IValidator<DecorationGroup> validator)
    {
        _decorationRepository = foodRepository;
        _validator = validator;
    }

    public async Task<DecorationGroup> Execute(AddDecorationToPartyDto decorationDto)
    {
        var decoration = decorationDto.ToModel;
        ValidationUtils.Validate(_validator, decoration, "Validation for food fail");

        return await _decorationRepository.Add(decoration);
    }
}
