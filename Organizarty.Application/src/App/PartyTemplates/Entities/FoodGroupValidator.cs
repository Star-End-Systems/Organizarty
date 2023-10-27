using FluentValidation;

namespace Organizarty.Application.App.Party.Entities;

public class FoodGroupValidator : AbstractValidator<FoodGroup>
{
    public FoodGroupValidator()
    {
        RuleFor(x => x.Quantity).Must(x => x > 0).WithMessage("Quantity must be greater than zero");
        RuleFor(x => x.Note).Length(5, 256).When(food => !string.IsNullOrWhiteSpace(food.Note));
    }
}
