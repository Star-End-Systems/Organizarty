using Organizarty.Application.App.ServiceTypes.Entities;

namespace Organizarty.Application.App.ServiceTypes.UseCases;

public record CreateServiceTypeDto(string name, string description, Guid thirdPartyId)
{
    public ServiceType ToModel
      => new ServiceType
      {
          Name = name,
          Description = description,
          ThirdPartyId = thirdPartyId
      };
}
