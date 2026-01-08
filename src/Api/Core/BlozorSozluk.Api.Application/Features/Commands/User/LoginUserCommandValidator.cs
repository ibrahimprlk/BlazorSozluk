using BlozorSozluk.Common.ViewModels.RequestModels;
using FluentValidation;

namespace BlozorSozluk.Api.Application.Features.Commands.User
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand> // icerisine verdigimiz bu parametre degeri icin dogrulama yapacagini soyluyoruz
    {
        public LoginUserCommandValidator()
        {
            RuleFor(i => i.EmailAddress)
                .NotNull()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("{PropertyName} not a valid email address.");

            RuleFor(i => i.Password)
                .NotNull()
                .MinimumLength(6)
                .WithMessage("{PropertyName} should at least be {MinLength} characters.");

        }
    }
}
