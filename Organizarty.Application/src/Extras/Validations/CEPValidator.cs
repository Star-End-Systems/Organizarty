using System.Text.RegularExpressions;
using FluentValidation;

namespace Organizarty.Application.Extras.Validators;

public static class CEPValidator
{
    public static IRuleBuilderInitial<T, string> ValidCEP<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return (IRuleBuilderInitial<T, string>)ruleBuilder.Custom((cep, context) =>
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                context.AddFailure($"'{context.DisplayName}' não pode ser nulo ou vazio.");
                return;
            }

            ruleBuilder.Length(8);

            var cleanCEP = Regex.Replace(cep!, @"[^\d]", "");

            if (cleanCEP[0] == '0')
            {
                context.AddFailure($"'{context.DisplayName}' não pode iniciar com 0.");
                return;
            }

            if (!Regex.IsMatch(cleanCEP, @"^\d+$"))
            {
                context.AddFailure($"'{context.DisplayName}' em formato incorreto.");
                return;
            }
        });
    }
}


