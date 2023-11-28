using FluentValidation;
using Organizarty.Application.App.Foods.Data;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Application.Exceptions;
using Organizarty.Application.Extras;

namespace Organizarty.Application.App.Foods.UseCases;

public record EditFoodSubItemDto(Guid id, bool avaible, string flavour, decimal price, List<string> images);

public class EditFoodSubItemUseCase
{
    private readonly IFoodInfoRepository _foodRepository;
    private readonly IValidator<FoodInfo> _validator;

    public EditFoodSubItemUseCase(IFoodInfoRepository foodRepository, IValidator<FoodInfo> validator)
    {
        _foodRepository = foodRepository;
        _validator = validator;
    }

    public async Task<FoodInfo> Execute(EditFoodSubItemDto foodDto)
    {
        var food = await _foodRepository.FindById(foodDto.id) ?? throw new NotFoundException("Food not found.");

        food.Available = foodDto.avaible;
        food.Flavour = foodDto.flavour;
        food.Price = foodDto.price;
        food.Images = foodDto.images;

        ValidationUtils.Validate(_validator, food, "Falha enquanto valida Produto.");

        return await _foodRepository.Update(food);
    }

}
