using FluentValidation;
using Organizarty.Adapters;
using Organizarty.Application.App.ThirdParties.Data;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.ThirdParties.UseCases;

public class RegisterThirdPartyUseCase
{
    private readonly ICryptographys _cryptographys;
    private readonly IThirdPartyRepository _thirdPartyRepository;
    private readonly IValidator<ThirdParty> _validator;

    public RegisterThirdPartyUseCase(IThirdPartyRepository thirdPartyRepository, ICryptographys cryptographys, IValidator<ThirdParty> validator)
    {
        _thirdPartyRepository = thirdPartyRepository;
        _cryptographys = cryptographys;
        _validator = validator;
    }

    public async Task<ThirdParty> Execute(RegisterThirdPartyDto thirdPartyDto)
    {
        var thirdparty = thirdPartyDto.ToModel;
        Validate(thirdparty);

        var (hashedPassword, salt) = _cryptographys.HashPassword(thirdPartyDto.Password);

        thirdparty.Password = hashedPassword;
        thirdparty.Salt = salt;

        return await _thirdPartyRepository.Create(thirdparty);
    }

    private void Validate(ThirdParty thirdParty)
    {
        var result = _validator.Validate(thirdParty);

        if (!result.IsValid)
        {
            throw new ValidationFailException("Fail while valiating user.", result.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
