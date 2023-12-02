using Organizarty.Application.App.Foods.Data;
using Organizarty.Application.App.Foods.Entities;

namespace Organizarty.Application.App.Foods.UseCases;

public class SelectFoodsUseCase
{
    private readonly IFoodInfoRepository _infoRepository;
    private readonly IFoodTypeRepository _typeRepository;

    public SelectFoodsUseCase(IFoodInfoRepository foodRepository, IFoodTypeRepository typeRepository)
    {
        _infoRepository = foodRepository;
        _typeRepository = typeRepository;
    }

    public async Task<List<FoodType>> AllFoodsFromThirdParty(Guid id)
      => await _typeRepository.AllFoodsFromThirdParty(id);

    public async Task<List<FoodType>> AllFoodsAvaible()
      => await _typeRepository.AllFoods(true);

    public async Task<FoodType?> FindFoodById(Guid id)
      => await _typeRepository.FindById(id);

    public async Task<FoodInfo?> FindByIdWithDetail(Guid id)
      => await _infoRepository.FindWithIdWithDetail(id);

    public async Task<FoodInfo?> FindFoodSubItem(Guid id)
      => await _infoRepository.FindById(id);
}
