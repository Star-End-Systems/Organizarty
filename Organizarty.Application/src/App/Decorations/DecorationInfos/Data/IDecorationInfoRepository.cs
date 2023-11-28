using Organizarty.Application.App.DecorationInfos.Entities;

namespace Organizarty.Application.App.DecorationInfos.Data;

public interface IDecorationInfoRepository
{
    Task<DecorationInfo> Create(DecorationInfo decoration);
    Task<DecorationInfo> Update(DecorationInfo decoration);

    Task<DecorationInfo?> FindById(Guid id);
    Task<DecorationInfo?> FindByIdWithType(Guid id);
    
}
