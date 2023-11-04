using FluentValidation;
using Organizarty.Application.App.DecorationInfos.Data;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.DecorationInfos.UseCases;

public class CreateDecorationInfoUseCase
{
    private readonly IDecorationInfoRepository _decorationRepository;
    private readonly IValidator<DecorationInfo> _validator;

    public CreateDecorationInfoUseCase(IDecorationInfoRepository decorationRepository, IValidator<DecorationInfo> validator)
    {
        _decorationRepository = decorationRepository;
        _validator = validator;
    }

    public async Task<DecorationInfo> Execute(CreateDecorationInfoDto decorationInfoDto)
    {
        var decoration = decorationInfoDto.ToModel;
        ValidationUtils.Validate(_validator, decoration, "Fail to create decoration");

        return await _decorationRepository.Create(decoration);
    }
}
