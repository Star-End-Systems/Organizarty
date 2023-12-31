using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Application.App.Users.Data;

public interface IUserConfirmationRepository
{
    Task<UserConfirmation> Create(UserConfirmation user);
    Task<UserConfirmation?> FindById(string id);
    Task<UserConfirmation?> FindByCode(string email, string code);
    Task<List<UserConfirmation>> FindByUserEmail(string userEmail);
    Task RemoveAllFromUser(string userEmail);
}
