using Organizarty.Application.App.Users.Entities;
using Organizarty.Application.App.Users.Data;
using Organizarty.Adapters;
using FluentValidation;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Users.UseCases;

public class RegisterUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptographys _cryptographys;
    private readonly IValidator<User> _userValidator;

    public RegisterUserUseCase(IUserRepository userRepository, ICryptographys cryptographys, IValidator<User> userValidator)
    {
        _userRepository = userRepository;
        _cryptographys = cryptographys;
        _userValidator = userValidator;
    }

    public async Task<User> Execute(RegisterUserDto userDto)
    {
        var user = userDto.ToModel;

        ValidationUtils.Validate(_userValidator, user, "Fail while valiating user.");

        var (password, salt) = _cryptographys.HashPassword(user.Password);

        user.Password = password;
        user.Salt = salt;

        return await _userRepository.Create(user);
    }
}
