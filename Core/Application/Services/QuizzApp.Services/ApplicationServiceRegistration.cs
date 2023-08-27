using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Services;
using QuizzApp.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Services
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IValidator<CategoryDTO>, CategoryValidator>()
                .AddScoped<IValidator<UserToUpsertDTO>, UserValidator>();
            return services;
        }
    }
}
