using FluentValidation;
using Organizarty.Adapters;
using Organizarty.Application.App.Managers.Data;
using Organizarty.Application.App.Managers.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Managers.UseCases;

public class RegisterManagerUseCase
{
    private readonly IManagerRepository _managerRepository;
    private readonly IValidator<Manager> _validator;
    private readonly ICryptographys _cryptographys;

    public RegisterManagerUseCase(IManagerRepository managerRepository, IValidator<Manager> validator, ICryptographys cryptographys)
    {
        _managerRepository = managerRepository;
        _validator = validator;
        _cryptographys = cryptographys;
    }

    public async Task<Manager> Execute(RegisterManagerDto managerDto)
    {
        var manager = managerDto.ToModel;

        ValidationUtils.Validate(_validator, manager, "Fail while validating manager.");

        var (password, salt) = _cryptographys.HashPassword(manager.Password);

        manager.Password = password;
        manager.Salt = salt;

        return await _managerRepository.Create(manager);
    }
}
