using Organizarty.Application.App.Managers.Entities;
namespace Organizarty.Application.App.Managers.Data;

public interface IManagerRepository
{
    Task<Manager> Create(Manager manager);
    Task<Manager?> FindByEmail(string email);
    Task<Manager?> FindById(string id);
}
