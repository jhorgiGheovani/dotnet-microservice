using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address format");

        //Password Validation
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required");

        // Person Name
        RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("Person Name is required");

        //Gender
        RuleFor(x => x.Gender)
        .Must(value => Enum.TryParse(typeof(GenderOptions), value, true, out _))
        .WithMessage("Invalid gender option");

    }

}
