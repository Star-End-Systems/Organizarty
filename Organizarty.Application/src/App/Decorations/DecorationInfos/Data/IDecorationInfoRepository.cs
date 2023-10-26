using Organizarty.Application.App.DecorationInfos.Entities;

namespace Organizarty.Application.App.DecorationInfos.Data;

public interface IDecorationInfoRepository
{
    Task<DecorationInfo> Create(DecorationInfo decoration);
}
