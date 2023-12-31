using Organizarty.Application.App.Services.Data;
using Organizarty.Application.App.Services.Entities;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.App.Services.UseCases;

public class SelectServicesUseCase
{
    private readonly IServiceTypeRepository _serviceTypeRepository;
    private readonly IServiceInfoRepository _serviceInfoRepository;

    public SelectServicesUseCase(IServiceTypeRepository serviceTypeRepository, IServiceInfoRepository serviceInfoRepository)
    {
        _serviceTypeRepository = serviceTypeRepository;
        _serviceInfoRepository = serviceInfoRepository;
    }

    public async Task<ServiceType> FindServiceById(string id)
      => await _serviceTypeRepository.FindByIdWithItens(id) ?? throw new NotFoundException("Service not found");

    public async Task<ServiceInfo> FindSubServiceById(string id)
      => await _serviceInfoRepository.FindById(id) ?? throw new NotFoundException("Service not found");

    public async Task<ServiceInfo> FindSubServiceByIdParent(string id)
      => await _serviceInfoRepository.FindByIdWithParent(id) ?? throw new NotFoundException("Service not found");

    public async Task<List<ServiceType>> FindServicesByThirdParty(string thirdParty)
      => await _serviceTypeRepository.FindByThirdParty(thirdParty);

    public async Task<List<ServiceType>> GetAvaibleServices()
      => await _serviceTypeRepository.GetAvaibleServices();
}
