using FluentValidation;

namespace Organizarty.Application.App.Managers.Entities;

public class ManagerValidator : AbstractValidator<Manager>
{
    public ManagerValidator()
    {
        RuleFor(x => x.Name).Length(5, 50);
        RuleFor(x => x.Email).EmailAddress().NotNull();
        RuleFor(x => x.Password).MinimumLength(8).NotNull();
    }
}
