using System.Text.Json;

namespace Organizarty.Application.App.Services.Entities;

public class ServiceInfo
{
    public string Id { get; set; } = default!;

    public decimal Price { get; set; } = default!;
    public bool IsAvaible { get; set; } = default!;

    public string Plan { get; set; } = default!;
    public string ImagesJson { get; set; } = default!;

    public List<string> Images
    {
        get => JsonSerializer.Deserialize<List<string>>(ImagesJson ?? "[]") ?? new List<string>();
        set => ImagesJson = JsonSerializer.Serialize(value);
    }

    public string ServiceTypeId { get; set; } = default!;
    public ServiceType ServiceType { get; set; } = default!;
}
