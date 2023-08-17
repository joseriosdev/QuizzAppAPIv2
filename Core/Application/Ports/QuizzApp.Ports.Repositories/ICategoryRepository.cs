using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;

namespace QuizzApp.Ports.Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryForUpsert> CreateCategoryAsync(Category newCategory);
        Task<IEnumerable<CategoryForDisplay>> GetAllCategoriesAsync();

    }
}