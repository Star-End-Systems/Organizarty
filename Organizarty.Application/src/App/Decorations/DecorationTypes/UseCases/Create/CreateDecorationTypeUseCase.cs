using FluentValidation;
using Organizarty.Application.App.DecorationTypes.Data;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.DecorationTypes.UseCases;

public class CreateDecorationTypeUseCase
{
    private readonly IDecorationTypeRepository _decorationInfoRepository;
    private readonly IValidator<DecorationType> _validator;

    public CreateDecorationTypeUseCase(IDecorationTypeRepository decorationInfoRepository, IValidator<DecorationType> validator)
    {
        _decorationInfoRepository = decorationInfoRepository;
        _validator = validator;
    }

    public async Task<DecorationType> Execute(CreateDecorationTypeDto decorationTypeDto)
    {
        var decoration = decorationTypeDto.ToModel;
        ValidationUtils.Validate(_validator, decoration, "Fail to create decoration");

        return await _decorationInfoRepository.Create(decoration);
    }
}
