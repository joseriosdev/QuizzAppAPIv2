using FluentValidation;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Ports.Services;
using QuizzApp.Server.Models;
using QuizzApp.Services.Validations;

namespace QuizzApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepository = categoryRepo;
        }
        public async Task<Category> CreateAsync(CategoryDTO categoryDTO, CancellationToken cToken)
        {
            ValidateCategory(categoryDTO);
            Category? isDuplicated = await _categoryRepository.GetCategoryByNameAsync(categoryDTO.Name, cToken);
            if (isDuplicated != null)
            {
                throw new InvalidOperationException("Duplicated Category");
            }
            return await _categoryRepository.CreateCategoryAsync(categoryDTO, cToken);
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken cToken)
        {
            return await _categoryRepository.DeleteCategoryByIdAsync(id, cToken);
        }

        public async Task<Category?> FindByIdAsync(int id, CancellationToken cToken)
        {
            return await _categoryRepository.GetCategoryByIdAsync(id, cToken);
        }

        public async Task<IEnumerable<Category>> FindAllAsync(CancellationToken cToken)
        {
            return await _categoryRepository.GetAllCategoriesAsync(cToken);
        }

        public async Task<Category> UpdateByIdAsync(int id, CategoryDTO categoryDTO, CancellationToken cToken)
        {
            ValidateCategory(categoryDTO);
            return await _categoryRepository.UpdateCategoryByIdAsync(id, categoryDTO, cToken);
        }

        private void ValidateCategory(CategoryDTO category)
        {
            CategoryValidator cValidator = new ();
            cValidator.ValidateAndThrow(category);
        }
    }
}