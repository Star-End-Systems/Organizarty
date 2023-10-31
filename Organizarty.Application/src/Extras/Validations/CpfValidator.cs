using FluentValidation;

namespace Organizarty.Application.Extras.Validators;

public static class CpfValidator
{
    public static IRuleBuilderInitial<T, string> ValidCPF<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return (IRuleBuilderInitial<T, string>) ruleBuilder.Custom((cpf, context) =>
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                context.AddFailure($"'{context.DisplayName}' não pode ser nulo ou vazio.");
                return;
            }

            if(cpf.Length != 11)
            {
                context.AddFailure($"'{context.DisplayName}' Deve conter 11 digitos.");
                return;
            }
        });
    }
}


