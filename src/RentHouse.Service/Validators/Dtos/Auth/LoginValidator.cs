using FluentValidation;
using RentHouse.Service.Dtos.Auth;
using RentHouse.Service.Validators.Dtos.Apartments;

namespace RentHouse.Service.Validators.Dtos.Auth;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(dto => dto.Email).Must(email => EmailValidators.IsValid(email))
            .WithMessage("Email addres is invalid! example@gmail.com");

        RuleFor(dto => dto.Password).Must(password => PassWordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
