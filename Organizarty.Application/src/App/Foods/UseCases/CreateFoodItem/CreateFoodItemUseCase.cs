using FluentValidation;
using Organizarty.Application.App.Foods.Data;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Foods.UseCases;

public class CreateFoodItemUseCase
{
    private readonly IValidator<FoodInfo> _validator;
    private readonly IFoodInfoRepository _foodRepository;

    public CreateFoodItemUseCase(IFoodInfoRepository foodRepository, IValidator<FoodInfo> validator)
    {
        _validator = validator;
        _foodRepository = foodRepository;
    }

    public async Task<FoodInfo> Execute(CreateFoodItemDto foodDto)
    {
        var food = foodDto.ToModel;
        ValidationUtils.Validate(_validator, food, "Validation for food fail");

        return await _foodRepository.Create(food);
    }
}
