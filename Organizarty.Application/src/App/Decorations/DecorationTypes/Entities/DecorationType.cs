using System.Text.Json;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.App.Decorations.Entities;

namespace Organizarty.Application.App.DecorationTypes.Entities;

public class DecorationType
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Size { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string ObjectURL { get; set; } = default!;
    public DecorationCategory Category { get; set; } = default!;

    public string TagsJSON { get; set; } = "[]";

    public List<string> Tags
    {
        get => JsonSerializer.Deserialize<List<string>>(TagsJSON ?? "[]") ?? new List<string>();
        set => TagsJSON = JsonSerializer.Serialize(value);
    }

    public List<DecorationInfo> Decorations { get; set; } = new();

}
