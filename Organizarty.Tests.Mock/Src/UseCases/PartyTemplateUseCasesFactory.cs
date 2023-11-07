using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.UseCases;

namespace Organizarty.Tests.Mock.UseCases;

public partial class UseCasesFactory
{
    public CreatePartyUseCase CreatePartyUseCase()
    {
        var repo = _repositories.PartyTemplateRepository();

        return new CreatePartyUseCase(repo, new PartyTemplateValidator());
    }

    public AddFoodToPartyUseCase AddFoodToPartyUseCase()
    {
        var repo = _repositories.FoodGroupRepository();

        return new AddFoodToPartyUseCase(repo, new FoodGroupValidator());
    }

    public AddDecorationToPartyUseCase AddDecorationToPartyUseCase()
    {
        var repo = _repositories.DecorationGroupRepository();

        return new AddDecorationToPartyUseCase(repo, new DecorationGroupValidator());
    }

    public AddServiceToPartyUsecase AddServiceToPartyUsecase()
    {
        var repo = _repositories.ServiceGroupRepository();

        return new AddServiceToPartyUsecase(repo, new ServiceGroupValidator());
    }

    public SelectPartyUseCase SelectPartyUseCase()
    {
        var repoParty = _repositories.PartyTemplateRepository();
        var repoService = _repositories.ServiceGroupRepository();
        var repoDecoration = _repositories.DecorationGroupRepository();
        var repoFood = _repositories.FoodGroupRepository();

        return new SelectPartyUseCase(repoParty, repoDecoration, repoFood, repoService);
    }
}
