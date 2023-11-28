using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IDecorationGroupRepository
{
    Task<DecorationGroup> Add(DecorationGroup decoration);
    Task<DecorationGroup> Update(DecorationGroup decoration);
    Task Delete(Guid id);
    Task<List<DecorationGroup>> ListFromParty(Guid partyId);

    Task<DecorationGroup?> FindById(Guid id);
}
