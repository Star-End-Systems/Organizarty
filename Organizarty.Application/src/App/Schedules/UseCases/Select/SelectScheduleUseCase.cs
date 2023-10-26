using Organizarty.Application.App.Schedules.Data;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Schedules.UseCases;

public class SelectScheduleUseCase
{
    private readonly IScheduleRepository _scheduleRepository;

    public SelectScheduleUseCase(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<Schedule> FindById(Guid scheduleId)
    => await _scheduleRepository.FindById(scheduleId) ?? throw new NotFoundException("Schedule not found.");
}
