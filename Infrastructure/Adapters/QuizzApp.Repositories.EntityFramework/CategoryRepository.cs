using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Server.Models;

namespace QuizzApp.Repositories.EntityFramework
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly QuizApiContext _Context;

        public CategoryRepository(QuizApiContext context)
        {
            _Context = context;
        }

        public async Task<CategoryForUpsert> CreateCategoryAsync(Category category)
        {
            await _Context.Categories
                .AddAsync(category);
            var result = _Context.SaveChanges();

            if (result == 0)
            {
                // Handle case when upsert did not work
            }

            return category;
        }
        public Task<IEnumerable<CategoryForDisplay>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}