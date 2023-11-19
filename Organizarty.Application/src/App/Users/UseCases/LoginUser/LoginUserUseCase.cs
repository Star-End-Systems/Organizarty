using Organizarty.Adapters;
using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Users.UseCases;

public class LoginUserUseCase
{
    private readonly ICryptographys _cryptographys;
    private readonly IUserRepository _userRepository;

    public LoginUserUseCase(ICryptographys cryptographys, IUserRepository userRepository)
    {
        _cryptographys = cryptographys;
        _userRepository = userRepository;
    }

    public async Task<User> Execute(LoginUserDto userDto)
    {
        var user = await _userRepository.FindByEmailOrUsername(userDto.Email) ?? throw new NotFoundException($"User with email '{userDto.Email}' not found.");
        ValidCredentials(userDto.Password, user);

        return user;
    }

    private void ValidCredentials(string password, User user)
    {
        var valid = _cryptographys.VerifyPassword(password, user.Password ?? "", user.Salt ?? "");

        if (!valid)
        {
            throw new NotFoundException("Email or password is not valid.");
        }

        if (!user.EmailConfirmed)
        {
            throw new NotFoundException($"Pleace Confirm your email");
        }
    }
}

