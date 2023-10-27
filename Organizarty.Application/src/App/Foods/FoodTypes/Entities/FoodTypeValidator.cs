using FluentValidation;

namespace Organizarty.Application.App.FoodTypes.Entities;

public class FoodTypeValidator : AbstractValidator<FoodType>
{
    public FoodTypeValidator()
    {
        RuleFor(x => x.Name).Length(5, 35);
        RuleFor(x => x.Description).Length(15, 256);
    }
}
