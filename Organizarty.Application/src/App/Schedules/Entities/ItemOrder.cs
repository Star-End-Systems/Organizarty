using Organizarty.Application.App.Party.Enums;
using Organizarty.Application.App.Schedules.Enum;

namespace Organizarty.Application.App.Schedules.Entities;

public record ItemOrder(Guid id, ItemType type, string name, ItemStatus Status, int quantity, string note, decimal price, Guid scheduleId);
