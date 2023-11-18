using Organizarty.Application.App.Services.Entities;

namespace Organizarty.Application.App.Services.UseCases;

public record CreateServiceTypeDto(string name, string description, Guid thirdPartyId, List<string> tags)
{
    public ServiceType ToModel
      => new ServiceType
      {
          Name = name,
          Description = description,
          ThirdPartyId = thirdPartyId,
          Tags = tags
      };
}
