using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using QuizzApp.Repositories.EntityFramework;
using QuizzApp.Server.Models;
using System;

namespace QuizzApp.Test.Repositories
{
    public class CategoryRepositoryTests
    {
        private IMapper _mapper;

        public CategoryRepositoryTests()
        {
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task GetCategory_WhenCategoryExists_ReturnsCategory()
        {
            // Arrange
            var dbContextOptions = CreateNewContextOptions();
            using var context = new QuizApiContext(dbContextOptions);
            var categoryService = new CategoryRepository(
                context, _mapper);
            await context.Categories.AddAsync(new Category()
            {
                Id = 1,
                Name = "Test Category"
            });
            await context.SaveChangesAsync();

            var category = 1;

            // Act
            var categoryResult = await categoryService
                .GetCategoryByIdAsync(category, default);

            // Assert
            categoryResult.Should().NotBeNull();
        }

        private DbContextOptions<QuizApiContext> CreateNewContextOptions()
        {
            // Use in-memory database for testing
            var optionsBuilder =
                new DbContextOptionsBuilder<QuizApiContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging();

            return optionsBuilder.Options;
        }
    }
}

