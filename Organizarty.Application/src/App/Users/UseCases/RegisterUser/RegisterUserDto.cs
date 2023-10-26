using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Application.App.Users.UseCases;

public record RegisterUserDto(string UserName, string Location, string Email, string Password)
{
    public User ToModel
      => new User
      {
          UserName = this.UserName,
          Email = this.Email,
          Password = this.Password,
          Location = this.Location,
      };
}
