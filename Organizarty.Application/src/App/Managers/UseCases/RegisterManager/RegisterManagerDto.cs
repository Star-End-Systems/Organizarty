using Organizarty.Application.App.Managers.Entities;

namespace Organizarty.Application.App.Managers.UseCases;

public record RegisterManagerDto(string Name, string Email, string Password)
{
    public Manager ToModel
      => new Manager
      {
          Name = Name,
          Email = Email,
          Password = Password
      };
}
