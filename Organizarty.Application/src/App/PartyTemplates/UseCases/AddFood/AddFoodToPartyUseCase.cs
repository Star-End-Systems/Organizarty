using FluentValidation;
using Organizarty.Application.App.Party.Data;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Party.UseCases;

public class AddFoodToPartyUseCase
{
    private readonly IFoodGroupRepository _foodRepository;
    private readonly IValidator<FoodGroup> _validator;

    public AddFoodToPartyUseCase(IFoodGroupRepository foodRepository, IValidator<FoodGroup> validator)
    {
        _foodRepository = foodRepository;
        _validator = validator;
    }

    public async Task Execute(AddFoodToPartyDto foodDto)
    {
        var food = foodDto.ToModel;
        ValidationUtils.Validate(_validator, food, "Validation for food fail");

        await _foodRepository.Add(food);
    }
}
