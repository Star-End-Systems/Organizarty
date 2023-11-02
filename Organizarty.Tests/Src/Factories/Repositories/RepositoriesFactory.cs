using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Tests.Factories.Repositories;

public partial class RepositoriesFactory
{
    private readonly ApplicationDbContext _context;

    public RepositoriesFactory(ApplicationDbContext context)
    {
        _context = context;
    }
}

