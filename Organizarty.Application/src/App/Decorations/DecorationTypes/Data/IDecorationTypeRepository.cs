using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.Decorations.Entities;

namespace Organizarty.Application.App.DecorationTypes.Data;

public interface IDecorationTypeRepository
{
    Task<DecorationType> Create(DecorationType decoration);
    Task<DecorationType> Update(DecorationType decoration);
    Task<List<DecorationType>> All();

    Task<DecorationType?> FindById(string id);
    Task<DecorationType?> FindByIdWithItems(string id);

    Task<List<DecorationType>> FindByCategory(DecorationCategory Category);

    Task<List<DecorationType>> GetWithAvaible(bool avaible);
}
