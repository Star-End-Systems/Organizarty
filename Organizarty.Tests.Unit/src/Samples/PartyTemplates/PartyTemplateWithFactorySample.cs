using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.Enums;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Tests.Mock.UseCases;

namespace Organizarty.Tests.Unit.Samples.PartyTemplates;

public static partial class PartyTemplateSample
{
    public static async Task<PartyTemplate> SetuoPartyTemplate(UseCasesFactory usecases, Guid locationId, Guid userid)
    {
        var data = new CreatePartyDto("Festa de coxinhas", 50, PartyType.chadebebe, locationId, userid);
        var createParty = usecases.CreatePartyUseCase();

        return await createParty.Execute(data);
    }
}
