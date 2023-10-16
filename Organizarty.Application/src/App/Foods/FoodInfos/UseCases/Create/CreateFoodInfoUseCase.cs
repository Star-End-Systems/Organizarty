using FluentValidation;
using Organizarty.Application.App.FoodInfos.Data;
using Organizarty.Application.App.FoodInfos.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.FoodInfos.UseCases;

public class CreateFoodInfoUseCase
{
    private readonly IValidator<FoodInfo> _validator;
    private readonly IFoodInfoRepository _foodRepository;

    public CreateFoodInfoUseCase(IFoodInfoRepository foodRepository, IValidator<FoodInfo> validator)
    {
        _validator = validator;
        _foodRepository = foodRepository;
    }

    public async Task Execute(CreateFoodInfoDto foodDto)
    {
        var food = foodDto.ToModel;
        ValidationUtils.Validate(_validator, food, "Validation for food fail");

        await _foodRepository.Create(food);
    }
}
