using Organizarty.Application.App.DecorationTypes.Entities;

namespace Organizarty.Application.App.DecorationTypes.Data;

public interface IDecorationTypeRepository
{
    Task<DecorationType> Create(DecorationType decoration);
    Task<List<DecorationType>> All();
}
