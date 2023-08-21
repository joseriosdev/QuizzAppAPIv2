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
        public UserValidator() { }
    }
}
