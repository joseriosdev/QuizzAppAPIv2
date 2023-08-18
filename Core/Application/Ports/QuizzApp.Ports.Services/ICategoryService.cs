using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;
using System.Threading;

namespace QuizzApp.Ports.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(CategoryDTO categoryDTO, CancellationToken cToken);
        Task<IEnumerable<Category>> FindAllAsync(CancellationToken cToken);
        Task<Category?> FindByIdAsync(int id, CancellationToken cToken);
        Task<Category> UpdatepByIdAsync(int id, CategoryDTO categoryDTO, CancellationToken cToken);
        Task<bool> DeleteByIdAsync(int id, CancellationToken cToken);
    }
}