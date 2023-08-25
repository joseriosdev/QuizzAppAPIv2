using FluentValidation;
using QuizzApp.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Services.Validations
{
    public class UserValidator : AbstractValidator<UserToUpsertDTO>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(2).MaximumLength(20);
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email address");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.");
                //.Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                //.Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                //.Matches("[0-9]").WithMessage("Password must contain at least one digit.")
                //.Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
        }
    }
}
