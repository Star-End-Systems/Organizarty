using FluentValidation;
using Organizarty.Application.App.FoodTypes.Data;
using Organizarty.Application.App.FoodTypes.Entities;
using Organizarty.Application.Exceptions;

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
        Validate(food);

        return await _foodRepository.Create(food);
    }

    private void Validate(FoodType food)
    {
        var result = _validator.Validate(food);

        if (!result.IsValid)
        {
            throw new ValidationFailException("Fail while valiating user.", result.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}
