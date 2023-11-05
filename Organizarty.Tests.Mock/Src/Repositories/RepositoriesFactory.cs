using Organizarty.Infra.Data.Contexts;

namespace Organizarty.Tests.Mock.Repositories;

public partial class RepositoriesFactory
{
    private readonly ApplicationDbContext _context;

    public RepositoriesFactory(ApplicationDbContext context)
    {
        _context = context;
    }
}

