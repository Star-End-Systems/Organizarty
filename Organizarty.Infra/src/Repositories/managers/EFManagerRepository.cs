using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.Managers.Data;
using Organizarty.Application.App.Managers.Entities;
using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Infra.Repositories.Managers;

public class EFManagerRepository : IManagerRepository
{
    private readonly ApplicationDbContext _context;

    public EFManagerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Manager> Create(Manager manager)
    {
        var d = await _context.Managers.AddAsync(manager);
        await _context.SaveChangesAsync();

        return d.Entity;
    }

    public async Task<Manager?> FindByEmail(string email)
    => await _context.Managers.Where(x => x.Email == email).FirstOrDefaultAsync();
}
