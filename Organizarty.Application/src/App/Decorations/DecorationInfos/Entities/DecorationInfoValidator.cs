using FluentValidation;

namespace Organizarty.Application.App.DecorationInfos.Entities;

public class DecorationInfoValidator : AbstractValidator<DecorationInfo>
{
    public DecorationInfoValidator()
    {
        RuleFor(x => x.Color).Length(1, 32);
        RuleFor(x => x.Material).Length(1, 32);

        RuleFor(x => x.Price).GreaterThan(5);
        RuleFor(x => x.TextureURL).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Invalid URL");
    }
}
