using FluentValidation;

namespace Organizarty.Application.App.DecorationTypes.Entities;

public class DecorationTypeValidator : AbstractValidator<DecorationType>
{
    public DecorationTypeValidator()
    {
        RuleFor(x => x.Name).Length(5, 32);
        RuleFor(x => x.Description).Length(5, 256);
        RuleFor(x => x.Size).Length(1, 8);
        RuleFor(x => x.Model).Length(3, 32);
        RuleFor(x => x.ObjectURL).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Invalid URL");
    }
}
