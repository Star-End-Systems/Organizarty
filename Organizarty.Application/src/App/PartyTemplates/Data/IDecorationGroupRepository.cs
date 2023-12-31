using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Application.App.Party.Data;

public interface IDecorationGroupRepository
{
    Task<DecorationGroup> Add(DecorationGroup decoration);
    Task<DecorationGroup> Update(DecorationGroup decoration);
    Task Delete(string id);
    Task<List<DecorationGroup>> ListFromParty(string partyId);

    Task<DecorationGroup?> FindById(string id);
}
