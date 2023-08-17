using Microsoft.EntityFrameworkCore;
using QuizzApp.Ports.Repositories;
using QuizzApp.Repositories.EntityFramework;
using QuizzApp.Server.Models;

namespace QuizzApp.Server
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            services.AddDbContext<QuizApiContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString
                    ("QuizAPIConnectionString"))
                .LogTo(
                    Console.WriteLine,
                    new[] { DbLoggerCategory.Database.Command.Name },
                    Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging(
                    env == "Development"));

            // Add Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
