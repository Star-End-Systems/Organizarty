using Organizarty.Application.App.DecorationTypes.Entities;

namespace Organizarty.Application.App.DecorationTypes.Data;

public interface IDecorationTypeRepository
{
    Task<DecorationType> Create(DecorationType decoration);
    Task<DecorationType> Update(DecorationType decoration);
    Task<List<DecorationType>> All();

    Task<DecorationType?> FindById(Guid id);

    Task<List<DecorationType>> GetWithAvaible(bool avaible);
}
