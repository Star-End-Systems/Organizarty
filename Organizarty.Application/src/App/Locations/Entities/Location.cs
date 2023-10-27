using System.Text.Json;

namespace Organizarty.Application.App.Locations.Entities;

public class Location
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? AreaSize { get; set; }

    public decimal RentPerDay { get; set; } = default!;

    public string? ImagesJson { get; set; }

    public List<string> Images
    {
        get => JsonSerializer.Deserialize<List<string>>(ImagesJson ?? "[]") ?? new List<string>();
        set => ImagesJson = JsonSerializer.Serialize(value);
    }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
