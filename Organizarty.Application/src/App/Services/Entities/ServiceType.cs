using System.Text.Json;
using Organizarty.Application.App.Services.Enums;
using Organizarty.Application.App.ThirdParties.Entities;

namespace Organizarty.Application.App.Services.Entities;

public class ServiceType
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public ServiceCategory Category { get; set; }

    public string ThirdPartyId { get; set; } = default!;
    public ThirdParty ThirdParty { get; set; } = default!;

    public ICollection<ServiceInfo> SubServices { get; set; } = default!;

    public string TagsJSON { get; set; } = "[]";

    public List<string> Tags
    {
        get => JsonSerializer.Deserialize<List<string>>(TagsJSON ?? "[]") ?? new List<string>();
        set => TagsJSON = JsonSerializer.Serialize(value);
    }
}
