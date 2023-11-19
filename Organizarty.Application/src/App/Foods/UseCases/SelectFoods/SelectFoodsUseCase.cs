using FluentValidation;
using Organizarty.Application.App.Foods.Data;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.Extras;

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

    public async Task<List<FoodType>> AllFoodsAvaible()
      => await _typeRepository.AllFoods(true);
}
