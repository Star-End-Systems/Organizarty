using Organizarty.Adapters;
using Organizarty.Application.App.Users.Data;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Users.UseCases;

public class LoginUserUseCase
{
    private readonly ICryptographys _cryptographys;
    private readonly IUserRepository _userRepository;
    private readonly ITokenProvider _tokenProvider;

    public LoginUserUseCase(ICryptographys cryptographys, IUserRepository userRepository, ITokenProvider token)
    {
        _cryptographys = cryptographys;
        _userRepository = userRepository;
        _tokenProvider = token;
    }

    public async Task<(User User, string Token)> Execute(LoginUserDto userDto)
    {
        var user = await _userRepository.FindByEmail(userDto.Email) ?? throw new NotFoundException($"User with email '{userDto.Email}' not found.");
        ValidCredentials(userDto.Password, user);
        var token = _tokenProvider.GenerateToken(user.Id.ToString(), userDto.Email);

        return (user, token);
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

