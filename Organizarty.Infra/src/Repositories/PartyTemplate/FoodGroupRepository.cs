using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.PartyTemplate;

public class FoodGroupRepository : IFoodGroupRepository
{
    private readonly ApplicationDbContext _context;

    public FoodGroupRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FoodGroup> Add(FoodGroup group)
    {
        await _context.FoodGroups.AddAsync(group);
        await _context.SaveChangesAsync();
        return group;
    }

    public async Task<List<FoodGroup>> ListFromParty(Guid partyId)
      => await _context.FoodGroups.Where(x => x.PartyTemplateId == partyId).Include(x => x.FoodInfo).Include(x => x.FoodInfo!.FoodType).ToListAsync();
}

