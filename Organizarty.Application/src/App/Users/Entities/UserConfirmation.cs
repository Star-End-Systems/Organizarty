namespace Organizarty.Application.App.Users.Entities;

public class UserConfirmation
{
    public Guid Id { get; set; } = default!;

    public Guid UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public DateTime ValidFor { get; set; } = DateTime.Now;
}
