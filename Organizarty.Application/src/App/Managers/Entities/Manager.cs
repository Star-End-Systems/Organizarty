namespace Organizarty.Application.App.Managers.Entities;

public class Manager
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
    public string Salt { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
