using Organizarty.Application.App.Services.Entities;

namespace Organizarty.Application.App.Services.UseCases;

public record CreateserviceInfoDto(decimal price, bool isAvaiable, string plan, List<string> images, string serviceTypeId)
{
    public ServiceInfo ToModel
      => new ServiceInfo
      {
          Price = price,
          IsAvaible = isAvaiable,
          Plan = plan,
          Images = images,
          ServiceTypeId = serviceTypeId
      };
}
