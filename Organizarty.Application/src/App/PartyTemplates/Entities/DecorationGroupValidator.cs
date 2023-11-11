using FluentValidation;

namespace Organizarty.Application.App.Party.Entities;

public class DecorationGroupValidator : AbstractValidator<DecorationGroup>
{
    public DecorationGroupValidator()
    {
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.Note).MaximumLength(256).When(x => string.IsNullOrWhiteSpace(x.Note));

        RuleFor(x => x.DecorationInfoId).NotNull();
        RuleFor(x => x.PartyTemplateId).NotNull();
    }
}
