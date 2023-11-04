using System.Text.Json;

namespace Organizarty.Application.App.Users.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Fullname { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;

    public string Salt { get; set; } = default!;

    public string? CPF { get; set; }

    public bool EmailConfirmed { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public string? RolesJson { get; set; }

    public string? Location { get; set; }

    public string? ProfilePictureURL { get; set; }

    public List<string> Roles
    {
        get => JsonSerializer.Deserialize<List<string>>(RolesJson ?? "[]") ?? new List<string>();
        // TODO: Add more validations for save new roles.
        set => RolesJson = JsonSerializer.Serialize(value);
    }
}
