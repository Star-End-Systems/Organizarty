using Organizarty.Application.App.DecorationTypes.UseCases;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.DecorationTypes.Data;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.App.DecorationInfos.Data;
using Organizarty.Application.App.DecorationInfos.UseCases;

namespace Organizarty.Tests.Mock.UseCases;

public partial class UseCasesFactory
{
    public CreateDecorationTypeUseCase CreateDecorationTypeUseCase(IDecorationTypeRepository repo)
      => new CreateDecorationTypeUseCase(repo, new DecorationTypeValidator());

    public CreateDecorationInfoUseCase CreateDecorationInfoUseCase(IDecorationInfoRepository repo)
      => new CreateDecorationInfoUseCase(repo, new DecorationInfoValidator());
}
