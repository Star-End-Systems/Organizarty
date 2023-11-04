using Organizarty.Application.App.ServiceTypes.UseCases;
using Organizarty.Application.App.ServiceTypes.Entities;
using Organizarty.Application.App.ServiceInfos.Entities;
using Organizarty.Application.App.ServiceInfos.Data;
using Organizarty.Application.App.ServiceInfos.UseCases;
using Organizarty.Application.App.Services.Data;

namespace Organizarty.Tests.Factories.UseCases;

public partial class UseCasesFactory
{
    public CreateServiceTypeUseCase CreateServiceTypeUseCase(IServiceTypeRepository repo)
      => new CreateServiceTypeUseCase(repo, new ServiceTypeValidator());

    public CreateServiceInfoUseCase CreateServiceInfoUseCase(IServiceInfoRepository repo)
      => new CreateServiceInfoUseCase(repo, new ServiceInfoValidator());
}
