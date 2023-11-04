using FluentValidation;
using Organizarty.Application.Extras.Validators;

namespace Organizarty.Application.App.Locations.Entities;

public class LocationValidator : AbstractValidator<Location>
{
    public LocationValidator()
    {
        RuleFor(x => x.Name).Length(5, 50);
        RuleFor(x => x.Description).Length(15, 256);

        // RuleFor(x => x.CEP).ValidCEP();
        RuleFor(x => x.CEP).NotNull().Length(8);

        RuleFor(x => x.Category).NotNull().Length(10, 32);

        RuleFor(x => x.Address).NotNull().Length(8, 32);

        RuleFor(x => x.Cords).NotNull().MaximumLength(16);

        RuleFor(x => x.AreaSize).Must(x => x > 1).WithMessage("Area must be greater than one.");
        RuleFor(x => x.RentPerDay).Must(x => x > 0).WithMessage("Rent must be greater than zero.");
        RuleForEach(x => x.Images).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Invalid URL");
    }
}
