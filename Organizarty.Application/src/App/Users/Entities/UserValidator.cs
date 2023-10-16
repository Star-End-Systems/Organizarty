using FluentValidation;

namespace Organizarty.Application.App.Users.Entities;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.UserName).Length(5, 50);

        RuleFor(x => x.ProfilePictureURL)
          .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
          .When(x => !string.IsNullOrWhiteSpace(x.ProfilePictureURL))
          .WithMessage("Invalid URL");
    }
}
