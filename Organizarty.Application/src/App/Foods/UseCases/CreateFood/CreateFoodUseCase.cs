using FluentValidation;
using Organizarty.Application.App.Foods.Data;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Foods.UseCases;

public class CreateFoodUseCase
{
    private readonly IValidator<FoodType> _validator;
    private readonly IFoodTypeRepository _foodRepository;

    public CreateFoodUseCase(IFoodTypeRepository foodRepository, IValidator<FoodType> validator)
    {
        _validator = validator;
        _foodRepository = foodRepository;
    }

    public async Task<FoodType> Execute(CreateFoodDto foodTypeDto)
    {
        var food = foodTypeDto.ToModel;
        ValidationUtils.Validate(_validator, food, "Fail while valiating user.");

        return await _foodRepository.Create(food);
    }
}
