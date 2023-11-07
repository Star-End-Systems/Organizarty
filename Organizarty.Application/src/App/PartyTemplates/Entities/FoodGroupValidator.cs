using FluentValidation;

namespace Organizarty.Application.App.Party.Entities;

public class FoodGroupValidator : AbstractValidator<FoodGroup>
{
    public FoodGroupValidator()
    {
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.Note).Length(5, 256).When(food => !string.IsNullOrWhiteSpace(food.Note));
    }
}
