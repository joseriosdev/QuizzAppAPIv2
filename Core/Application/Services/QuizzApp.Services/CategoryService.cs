using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Ports.Services;
using QuizzApp.Server.Models;

namespace QuizzApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepository = categoryRepo;
        }
        public Task<Category> CreateAsync(CategoryDTO categoryDTO, CancellationToken cToken)
        {
            return _categoryRepository.CreateCategoryAsync(categoryDTO, cToken);
        }

        public Task<bool> DeleteByIdAsync(int id, CancellationToken cToken)
        {
            return _categoryRepository.DeleteCategoryByIdAsync(id, cToken);
        }

        public Task<Category?> FindByIdAsync(int id, CancellationToken cToken)
        {
            return _categoryRepository.GetCategoryByIdAsync(id, cToken);
        }

        public Task<IEnumerable<Category>> FindAllAsync(CancellationToken cToken)
        {
            return _categoryRepository.GetAllCategoriesAsync(cToken);
        }

        public Task<Category> UpdatepByIdAsync(int id, CategoryDTO categoryDTO, CancellationToken cToken)
        {
            return _categoryRepository.UpdateCategoryByIdAsync(id, categoryDTO, cToken);
        }
    }
}