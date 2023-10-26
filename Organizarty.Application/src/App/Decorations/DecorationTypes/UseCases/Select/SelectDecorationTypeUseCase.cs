using Organizarty.Application.App.DecorationTypes.Data;
using Organizarty.Application.App.DecorationTypes.Entities;

namespace Organizarty.Application.App.DecorationTypes.UseCases;

public class SelectDecorationTypeUseCase
{
    private readonly IDecorationTypeRepository _decorationTypeRepository;

    public SelectDecorationTypeUseCase(IDecorationTypeRepository decorationTypeRepository)
    {
        _decorationTypeRepository = decorationTypeRepository;
    }

    public async Task<List<DecorationType>> All()
    => await _decorationTypeRepository.All();
}
