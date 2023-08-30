using AutoMapper;
using FluentAssertions.Execution;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using QuizzApp.Ports.Repositories;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzApp.Ports.Services;
using QuizzApp.Services;
using QuizzApp.Domain.Models.Models;

namespace QuizzApp.Test.Services
{
    public class CategoryServiceTests
    {
        private ICategoryRepository _repository;

        public CategoryServiceTests()
        {
            _repository = Substitute.For<ICategoryRepository>();
        }

        [Fact]
        public async Task RetrieveCategory_WhenRepositoryReturnsCategory_ReturnsCategory()
        {
            // Arrange
            var categoryId = 1;
            var categoryRetrieved = new Category() { Id = categoryId };
            _repository.GetCategoryByIdAsync(categoryId, default)
                .ReturnsForAnyArgs(categoryRetrieved);
            var handler = HandlerInstace();

            // Act
            var result = await handler.FindByIdAsync(categoryId, default);

            // Assert
            using AssertionScope scope = new();
            result.Should().BeOfType<Category>();
            result.Id.Should().Be(categoryId);
        }

        private CategoryService HandlerInstace()
            => new(_repository);

    }
}
