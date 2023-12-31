namespace Organizarty.Application.App.Users.Entities;

public class UserConfirmation
{
    public string Id { get; set; } = default!;

    public string Code { get; set; } = default!;

    public string UserEmail { get; set; } = default!;

    public DateTime ValidFor { get; set; } = DateTime.Now;
}
