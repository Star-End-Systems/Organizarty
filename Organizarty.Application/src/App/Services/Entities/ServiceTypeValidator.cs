using FluentValidation;

namespace Organizarty.Application.App.Services.Entities;

public class ServiceTypeValidator : AbstractValidator<ServiceType>
{
    public ServiceTypeValidator()
    {
        RuleFor(x => x.Name).Length(5, 50);
        // RuleFor(x => x.Category).NotNull();
        RuleFor(x => x.Description).Length(0, 256).When(party => !string.IsNullOrWhiteSpace(party.Description));
        RuleFor(x => x.ThirdPartyId).NotNull();
    }
}
