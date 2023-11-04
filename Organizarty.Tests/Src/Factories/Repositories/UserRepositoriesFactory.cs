using Organizarty.Infra.Repositories.Users;

namespace Organizarty.Tests.Factories.Repositories;

public partial class RepositoriesFactory
{
    public UserRepository UserRepository()
      => new UserRepository(_context);

    public UserConfirmationRepository UserConfirmationRepository()
      => new UserConfirmationRepository(_context);
}

