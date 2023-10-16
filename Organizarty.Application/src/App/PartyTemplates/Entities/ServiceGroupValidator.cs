using FluentValidation;

namespace Organizarty.Application.App.Party.Entities;

public class ServiceGroupValidator : AbstractValidator<ServiceGroup>
{
    public ServiceGroupValidator()
    {
        RuleFor(x => x.Note).MaximumLength(256);

        RuleFor(x => x.ServiceInfoId).NotNull();
        RuleFor(x => x.PartyTemplateId).NotNull();
    }
}
