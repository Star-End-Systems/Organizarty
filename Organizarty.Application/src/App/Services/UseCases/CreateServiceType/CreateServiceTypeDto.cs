using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.App.Services.Enums;

namespace Organizarty.Application.App.Services.UseCases;

public record CreateServiceTypeDto(string name, string description, ServiceCategory category, string thirdPartyId, List<string> tags)
{
    public ServiceType ToModel
      => new ServiceType
      {
          Name = name,
          Description = description,
          Category = category,
          ThirdPartyId = thirdPartyId,
          Tags = tags
      };
}
