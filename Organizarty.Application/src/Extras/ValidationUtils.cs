using FluentValidation;
using Organizarty.Application.Exceptions;

namespace Organizarty.Application.Extras;

public static class ValidationUtils
{
    public static void Validate<T>(IValidator<T> validator, T value, string msg)
    {
        var result = validator.Validate(value);

        if (!result.IsValid)
        {
            throw new ValidationFailException(msg, result.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}

