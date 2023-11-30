using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Application.App.Users.UseCases;

public record RegisterUserDto(string UserName, string FullName, string Location, string Email, string Password, string? CPF)
{
    public User ToModel()
      => new User
      {
          UserName = this.UserName,
          Fullname = FullName,
          Email = this.Email,
          Password = this.Password,
          Location = this.Location,
          CPF = CPF
      };
}
