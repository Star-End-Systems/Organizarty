using System.Text.Json;
using Organizarty.Application.App.DecorationInfos.Entities;

namespace Organizarty.Application.App.DecorationTypes.Entities;

public class DecorationType
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Size { get; set; }
    public string? Model { get; set; }
    public string? ObjectURL { get; set; }

    public string TagsJSON { get; set; } = "[]";

    public List<string> Tags
    {
        get => JsonSerializer.Deserialize<List<string>>(TagsJSON ?? "[]") ?? new List<string>();
        set => TagsJSON = JsonSerializer.Serialize(value);
    }

    public ICollection<DecorationInfo> Decorations { get; set; } = default!;

}
