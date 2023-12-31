using Organizarty.Application.App.Party.Enums;
namespace Organizarty.Application.App.Party.Entities;

public record ItemOrder(string id, ItemType type, string name, int quantity, string note, decimal price, string partyId){
    public decimal TotalPrice => price * quantity;
}

