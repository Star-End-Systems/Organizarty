using FluentValidation;

namespace Organizarty.Application.App.Services.Entities;

public class ServiceInfoValidator : AbstractValidator<ServiceInfo>
{
    public ServiceInfoValidator()
    {
        RuleFor(x => x.Plan).Length(3, 64);
        RuleFor(x => x.Price).GreaterThan(5);
        RuleForEach(x => x.Images).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Invalid URL");
    }
}
