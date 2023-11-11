using Organizarty.Infra.Data.Contexts;
using Organizarty.Tests.Mock.Repositories;

namespace Organizarty.Tests.Mock.UseCases;

public partial class UseCasesFactory
{
    private ApplicationDbContext _context;
    private RepositoriesFactory _repositories;

    public UseCasesFactory(ApplicationDbContext context)
    {
        _context = context;
        _repositories = new RepositoriesFactory(_context);
    }
}

