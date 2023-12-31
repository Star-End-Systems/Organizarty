using Organizarty.Application.App.DecorationTypes.Data;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.Decorations.Entities;
using Organizarty.Application.Exceptions;

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

    public async Task<DecorationType> FindById(string id)
    => await _decorationTypeRepository.FindById(id) ?? throw new NotFoundException("Decoration not found.");

    public async Task<DecorationType> FindByIdWithItems(string id)
    => await _decorationTypeRepository.FindById(id) ?? throw new NotFoundException("Decoration not found.");
    public async Task<List<DecorationType>> FindByCategory(DecorationCategory Category)
    => await _decorationTypeRepository.FindByCategory(Category) ?? throw new NotFoundException("This category is empty.");

    public async Task<List<DecorationType>> GetAllAvaible()
    => await _decorationTypeRepository.GetWithAvaible(true);
}
