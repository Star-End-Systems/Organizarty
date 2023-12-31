using FluentValidation;
using Organizarty.Application.App.Foods.Data;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.Exceptions;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Foods.UseCases;

public record EditFoodDto(string id, string name, string description, string category, List<string> tags) { }

public class EditFoodUseCase
{
    private readonly SelectFoodsUseCase _selectFoods;
    private readonly IFoodTypeRepository _foodTypeRepository;
    private readonly IValidator<FoodType> _validator;

    public EditFoodUseCase(SelectFoodsUseCase selectFoods, IFoodTypeRepository foodTypeRepository, IValidator<FoodType> validator)
    {
        _selectFoods = selectFoods;
        _foodTypeRepository = foodTypeRepository;
        _validator = validator;
    }

    public async Task<FoodType> Execute(EditFoodDto foodDto)
    {
        var food = await _selectFoods.FindFoodById(foodDto.id) ?? throw new NotFoundException("Food not found.");

        food.Name = foodDto.name;
        food.Description = foodDto.description;
        food.Category = foodDto.category;
        food.Tags = foodDto.tags;

        ValidationUtils.Validate(_validator, food, "Falha enquanto valida Produto.");

        return await _foodTypeRepository.Update(food);
    }

}
