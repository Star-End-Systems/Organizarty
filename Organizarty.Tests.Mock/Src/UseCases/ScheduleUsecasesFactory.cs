using Organizarty.Application.App.Schedules.UseCases;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.UseCases;

namespace Organizarty.Tests.Mock.UseCases;

public partial class UseCasesFactory
{
    public ScheduleUseCase ScheduleUseCase()
    {
        var scheduleRepo = _repositories.ScheduleRepository();
        var partyRepo = _repositories.PartyTemplateRepository();

        return new ScheduleUseCase(scheduleRepo, partyRepo, new ScheduleValidation());
    }
}
