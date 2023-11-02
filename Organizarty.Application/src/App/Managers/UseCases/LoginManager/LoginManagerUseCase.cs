using Organizarty.Adapters;
using Organizarty.Application.App.Managers.Data;
using Organizarty.Application.App.Managers.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Managers.UseCases;

public class LoginManagerUseCase
{
    private readonly IManagerRepository _managerRepository;
    private readonly ICryptographys _cryptographys;

    public LoginManagerUseCase(IManagerRepository managerRepository, ICryptographys cryptographys)
    {
        _managerRepository = managerRepository;
        _cryptographys = cryptographys;
    }

    public async Task<Manager> Execute(LoginManagerDto managerDto)
    {
        var manager = await _managerRepository.FindByEmail(managerDto.Email) ?? throw new NotFoundException($"Can't find manager with email \"{managerDto.Email}\"");
        ValidCredentials(managerDto.Password, manager);

        return manager;
    }

    private void ValidCredentials(string password, Manager man)
    {
        var valid = _cryptographys.VerifyPassword(password, man.Password ?? "", man.Salt ?? "");

        if (!valid)
        {
            throw new NotFoundException("Email or password is not valid.");
        }
    }
}
