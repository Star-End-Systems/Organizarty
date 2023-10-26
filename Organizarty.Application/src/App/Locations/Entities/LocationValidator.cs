using FluentValidation;

namespace Organizarty.Application.App.Locations.Entities;

public class LocationValidator : AbstractValidator<Location>
{
    public LocationValidator()
    {
        RuleFor(x => x.Name).Length(5, 50);
        RuleFor(x => x.Description).Length(15, 256);
        RuleFor(x => x.AreaSize).Must(x => x > 1).WithMessage("Area must be greater than one.");
        RuleFor(x => x.RentPerDay).Must(x => x > 0).WithMessage("Rent must be greater than zero.");
        RuleForEach(x => x.Images).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Invalid URL");
    }
}
