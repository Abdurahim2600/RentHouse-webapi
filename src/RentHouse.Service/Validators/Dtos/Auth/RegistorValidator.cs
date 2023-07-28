using FluentValidation;
using Microsoft.AspNet.Identity;
using RentHouse.Service.Dtos.Auth;
using RentHouse.Service.Validators.Dtos.Apartments;

namespace RentHouse.Service.Validators.Dtos.Auth;

public class RegistorValidator : AbstractValidator<RegisterDto>
{
    public RegistorValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required!")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");
        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname is required!")
            .MaximumLength(30).WithMessage("Lastname must be less than 30 characters");

        RuleFor(dto => dto.Email).Must(email => EmailValidators.IsValid(email))
            .WithMessage("Email adress is invalid! ex: ____@gmail.com");

        RuleFor(dto => dto.Password).Must(password => PassWordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!"); 
        
    
    }
}
