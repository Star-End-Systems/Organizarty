using System.Text.Json;
namespace Organizarty.Application.App.Foods.Entities;

public class FoodInfo
{
    public string Id { get; set; } = default!;

    public string Flavour { get; set; } = default!;
    public decimal Price { get; set; }
    public bool Available { get; set; }

    public string? ImagesJson { get; set; }

    public List<string> Images
    {
        get => JsonSerializer.Deserialize<List<string>>(ImagesJson ?? "[]") ?? new List<string>();
        set => ImagesJson = JsonSerializer.Serialize(value);
    }

    public FoodType FoodType { get; set; } = default!;
    public string FoodTypeId { get; set; } = default!;
}
