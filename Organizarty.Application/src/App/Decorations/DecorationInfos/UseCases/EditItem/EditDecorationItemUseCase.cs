using FluentValidation;
using Organizarty.Application.App.DecorationInfos.Data;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.Exceptions;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.DecorationInfos.UseCases;

public class EditDecorationItemUseCase
{
    private readonly IDecorationInfoRepository _decorationRepository;
    private readonly IValidator<DecorationInfo> _validator;

    public EditDecorationItemUseCase(IDecorationInfoRepository decorationRepository, IValidator<DecorationInfo> validator)
    {
        _decorationRepository = decorationRepository;
        _validator = validator;
    }

    public async Task<DecorationInfo> Execute(EditDecorationItemDto decorationDto)
    {
        var decoration = await _decorationRepository.FindById(decorationDto.id) ?? throw new NotFoundException("Decoration not found.");

        decoration.Color = decorationDto.color;
        decoration.Material = decorationDto.material;
        decoration.IsAvaible = decorationDto.isAvailable;
        decoration.Price = decorationDto.price;
        decoration.TextureURL = decorationDto.textureURL;

        ValidationUtils.Validate(_validator, decoration, "Fail to create decoration");

        return await _decorationRepository.Update(decoration);
    }
}
