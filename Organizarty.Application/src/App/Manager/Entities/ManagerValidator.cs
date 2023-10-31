using System.Text.RegularExpressions;
using FluentValidation;

namespace Organizarty.Application.App.Manager.Entities;

public class LocationValidator : AbstractValidator<Manager>
{
    public LocationValidator()
    {
        RuleFor(x => x.Name).Length(5, 50);
        RuleFor(x => x.Email).EmailAddress().NotNull();
        RuleFor(x => x.Password).MinimumLength(8).NotNull();
    }
}
