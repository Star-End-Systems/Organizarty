using System.Text.Json;
using Organizarty.Application.App.Utils.Enums;

namespace Organizarty.Application.App.ThirdParties.Entities;

public class ThirdParty
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public string Address { get; set; } = default!;

    public string LoginEmail { get; set; } = default!;
    public string Salt { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ProfissionalPhone { get; set; } = default!;

    public string ContactEmail { get; set; } = default!;
    public string ContactPhone { get; set; } = default!;
    public string CNPJ { get; set; } = default!;

    public AuthorizationStatus AuthorizationStatus { get; set; } = AuthorizationStatus.Pending;

    public string ProfilePictureURL { get; set; } = default!;

    public string? TagJSON { get; set; }

    public List<string> Tag
    {
        get => JsonSerializer.Deserialize<List<string>>(TagJSON ?? "[]") ?? new List<string>();
        set => TagJSON = JsonSerializer.Serialize(value);
    }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
