using FluentValidation;
using Organizarty.Application.App.DecorationInfos.Data;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.Exceptions;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.DecorationInfos.UseCases;

public class SelectDecorationItemUseCase
{
    private readonly IDecorationInfoRepository _decorationRepository;

    public SelectDecorationItemUseCase(IDecorationInfoRepository decorationRepository)
    {
        _decorationRepository = decorationRepository;
    }

    public async Task<DecorationInfo> FinbById(Guid id)
    => await _decorationRepository.FindById(id) ?? throw new NotFoundException("Decoration not found.");
}
