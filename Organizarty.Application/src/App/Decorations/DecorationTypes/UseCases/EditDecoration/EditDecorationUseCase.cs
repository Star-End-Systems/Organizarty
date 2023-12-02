using FluentValidation;
using Organizarty.Application.App.DecorationTypes.Data;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.Exceptions;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.DecorationTypes.UseCases;

public class EditDecorationUseCase
{
    private readonly IDecorationTypeRepository _decorationTypeRepository;
    private readonly IValidator<DecorationType> _validator;

    public EditDecorationUseCase(IDecorationTypeRepository decorationTypeRepository, IValidator<DecorationType> validator)
    {
        _decorationTypeRepository = decorationTypeRepository;
        _validator = validator;
    }

    public async Task<DecorationType> Execute(EditDecorationDto decorationDto)
    {
        var decoration = await _decorationTypeRepository.FindById(decorationDto.id) ?? throw new NotFoundException("Decoration not found.");

        decoration.Name = decorationDto.name;
        decoration.Description = decorationDto.description;
        decoration.Category = decorationDto.category;
        decoration.Size = decorationDto.size;
        decoration.Model = decorationDto.model;
        decoration.ObjectURL = decorationDto.objectURL;
        decoration.Tags = decorationDto.Tags;

        ValidationUtils.Validate(_validator, decoration, "Fail to update decoration.");

        return await _decorationTypeRepository.Update(decoration);
    }
}
