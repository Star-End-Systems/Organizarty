using Organizarty.Application.App.ThirdParties.Entities;

namespace Organizarty.Application.App.ThirdParties.UseCases;

public record RegisterThirdPartyDto(string Name, string Description, string address, string LoginEmail, string Password, string ProfissionalPhone, string ContactEmail, string ContactPhone, string Cnpj, string ProfilePictureUrl, List<string> Tags)
{
    public ThirdParty ToModel
      => new ThirdParty
      {
          Name = Name,
          Description = Description,
          Address = address,
          LoginEmail = LoginEmail,
          Password = Password,
          ProfissionalPhone = ProfissionalPhone,
          ContactEmail = ContactEmail,
          ContactPhone = ContactPhone,
          CNPJ = Cnpj,
          ProfilePictureURL = ProfilePictureUrl,
          Tag = Tags
      };
}
