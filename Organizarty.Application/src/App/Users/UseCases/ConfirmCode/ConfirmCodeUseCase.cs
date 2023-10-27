using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Users.UseCases;

public class ConfirmCodeUseCase
{
    private readonly IUserConfirmationRepository _confirmRepository;
    private readonly IUserRepository _userRepository;
    private readonly TimeSpan TOKEN_MAX_AGE = TimeSpan.FromHours(24);

    public ConfirmCodeUseCase(IUserConfirmationRepository confirmRepository, IUserRepository userRepository)
    {
        _confirmRepository = confirmRepository;
        _userRepository = userRepository;
    }

    public async Task<User> Execute(Guid code)
    {
        var confirmation = await _confirmRepository.FindById(code) ?? throw new NotFoundException("Email code not founded");
        ValidEmailCode(confirmation);

        var user = confirmation.User;
        user.EmailConfirmed = true;

        var updatedUser = await _userRepository.Update(user);

        await _confirmRepository.RemoveAllFromUser(user.Id);

        return updatedUser;
    }

    private void ValidEmailCode(UserConfirmation confirmation)
    {
        if (confirmation.ValidFor <= DateTime.Now) { throw new ExpiredDataException("Email code expired"); }
    }
}
