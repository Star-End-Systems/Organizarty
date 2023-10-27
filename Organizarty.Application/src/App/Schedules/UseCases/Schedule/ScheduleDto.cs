namespace Organizarty.Application.App.Schedules.UseCases;

public record ScheduleDto(Guid partyId, DateTime startDate, DateTime endDate) { }
