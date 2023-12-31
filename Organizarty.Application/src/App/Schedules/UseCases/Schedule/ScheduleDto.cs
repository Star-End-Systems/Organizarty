namespace Organizarty.Application.App.Schedules.UseCases;

public record ScheduleDto(string partyId, DateTime startDate, int duration) { }
