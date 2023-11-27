using System.Text.Json;
using Organizarty.Application.App.ThirdParties.Entities;

namespace Organizarty.Application.App.Foods.Entities;

public class FoodType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;

    public ThirdParty ThirdParty { get; set; } = default!;
    public Guid ThirdPartyId { get; set; }

    public ICollection<FoodInfo> Foods { get; set; } = default!;

    public string TagsJSON { get; set; } = default!;

    public List<string> Tags
    {
        get => JsonSerializer.Deserialize<List<string>>(TagsJSON ?? "[]") ?? new List<string>();
        set => TagsJSON = JsonSerializer.Serialize(value);
    }
}
