using Organizarty.Application.App.Managers.Data;
using Organizarty.Application.App.Managers.Entities;

namespace Organizarty.Application.App.Managers.UseCases;

public class SelectManagerUseCase
{
    private readonly IManagerRepository _managerRepository;

    public SelectManagerUseCase(IManagerRepository managerRepository)
    {
        _managerRepository = managerRepository;
    }

    public async Task<Manager?> ById(Guid id)
      => await _managerRepository.FindById(id);
}
