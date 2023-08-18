using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;

namespace QuizzApp.Ports.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(CategoryDTO categoryDTO, CancellationToken cToken);
        Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cToken);
        Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cToken);
        Task<Category> UpdateCategoryByIdAsync(int id, CategoryDTO categoryDTO, CancellationToken cToken);
        Task<bool> DeleteCategoryByIdAsync(int id, CancellationToken cToken);
    }
}