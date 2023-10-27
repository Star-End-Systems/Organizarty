using FluentValidation;

namespace Organizarty.Application.App.FoodInfos.Entities;

public class FoodInfoValidator : AbstractValidator<FoodInfo>
{
    public FoodInfoValidator()
    {
        RuleFor(x => x.Flavour).Length(5, 35);
        RuleFor(x => x.Price).GreaterThan(5);
        RuleForEach(x => x.Images).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Invalid URL");
    }
}
