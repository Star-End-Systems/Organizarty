using Organizarty.Application.App.DecorationInfos.Data;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.Exceptions;

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

    public async Task<DecorationInfo> FinbByIdWithType(Guid id)
    => await _decorationRepository.FindByIdWithType(id) ?? throw new NotFoundException("Decoration not found.");
}
