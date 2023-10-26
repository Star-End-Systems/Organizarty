using Organizarty.Application.App.ServiceInfos.Entities;

namespace Organizarty.Application.App.ServiceInfos.UseCases;

public record CreateserviceInfoDto(decimal price, bool isAvaiable, string plan, List<string> images, Guid serviceTypeId)
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
