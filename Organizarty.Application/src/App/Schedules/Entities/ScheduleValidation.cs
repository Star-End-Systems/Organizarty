using FluentValidation;

namespace Organizarty.Application.App.Schedules.Entities;

public class ScheduleValidation : AbstractValidator<Schedule>
{
    public ScheduleValidation()
    {
        RuleFor(x => x.ExpectedGuests).GreaterThan(1);
        RuleFor(x => x.StartDate).GreaterThan(DateTime.Today);
        RuleFor(x => x).Must(x => x.StartDate > x.EndDate).WithMessage("End date must be after start date");
    }
}
