using FluentValidation;

namespace Organizarty.Application.App.ThirdParties.Entities;

public class ThirdPartyValidator : AbstractValidator<ThirdParty>
{
    public ThirdPartyValidator()
    {
        RuleFor(x => x.LoginEmail).EmailAddress().MaximumLength(256);
        RuleFor(x => x.ContactEmail).EmailAddress().MaximumLength(256);

        RuleFor(x => x.Name).Length(5, 50);
        RuleFor(x => x.Description).Length(15, 256);

        RuleFor(x => x.CNPJ).Length(14);

        RuleFor(x => x.ContactPhone).MinimumLength(11).MaximumLength(20);
        RuleFor(x => x.ProfissionalPhone).MinimumLength(11).MaximumLength(20);

        RuleFor(x => x.ProfilePictureURL)
          .NotNull()
          .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
          .WithMessage("Invalid URL");
    }
}
