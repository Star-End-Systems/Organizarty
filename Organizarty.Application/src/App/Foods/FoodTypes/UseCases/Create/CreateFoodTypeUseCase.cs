using FluentValidation;
using Organizarty.Application.App.FoodTypes.Data;
using Organizarty.Application.App.FoodTypes.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.FoodTypes.UseCases;

public class CreateFoodTypeUseCase
{
    private readonly IValidator<FoodType> _validator;
    private readonly IFoodTypeRepository _foodRepository;

    public CreateFoodTypeUseCase(IFoodTypeRepository foodRepository, IValidator<FoodType> validator)
    {
        _validator = validator;
        _foodRepository = foodRepository;
    }

    public async Task<FoodType> Execute(CreateFoodTypeDto foodTypeDto)
    {
        var food = foodTypeDto.ToModel;
        ValidationUtils.Validate(_validator, food, "Fail while valiating user.");

        return await _foodRepository.Create(food);
    }
}
