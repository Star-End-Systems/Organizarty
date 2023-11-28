using Organizarty.Application.App.Party.Enums;
namespace Organizarty.Application.App.Party.Entities;

public record ItemOrder(Guid id, ItemType type, string name, int quantity, string note, Guid partyId);

