using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Party.UseCases;
using Organizarty.Tests.Mock.UseCases;

namespace Organizarty.Tests.Unit.Samples.PartyTemplates;

public static partial class PartyTemplateSample
{
    public static async Task<PartyTemplate> SetuoPartyTemplate(UseCasesFactory usecases, Guid locationId)
    {
        var data = new CreatePartyDto("Festa de coxinhas", 50, locationId);
        var createParty = usecases.CreatePartyUseCase();

        return await createParty.Execute(data);
    }
}
