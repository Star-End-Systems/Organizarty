using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Application.App.Users.Data;

public interface IUserConfirmationRepository
{
    Task<UserConfirmation> Create(UserConfirmation user);
    Task<UserConfirmation?> FindById(Guid code);
    Task<List<UserConfirmation>> FindByUserId(Guid userId);
    Task RemoveAllFromUser(Guid userId);
}
