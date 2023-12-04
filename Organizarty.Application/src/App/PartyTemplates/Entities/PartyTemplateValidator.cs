using FluentValidation;

namespace Organizarty.Application.App.Party.Entities;

public class PartyTemplateValidator : AbstractValidator<PartyTemplate>
{
    public PartyTemplateValidator()
    {
        RuleFor(x => x.Name).Length(5, 50);
        RuleFor(x => x.ExpectedGuests).Must(x => x > 1).WithMessage("Guests number must be greater than one.");
    }
}
