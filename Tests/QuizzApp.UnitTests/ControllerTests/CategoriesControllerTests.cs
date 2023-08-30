using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using QuizzApp.Api.Rest.Controllers;
using QuizzApp.Ports.Services;
using QuizzApp.Server.Models;
using System;
using Xunit;

namespace QuizzApp.UnitTests.ControllerTests
{
    public class CategoriesControllerTests
    {
        private readonly ICategoryService _categoryService;

        public CategoriesControllerTests()
        {
            _categoryService = Substitute.For<ICategoryService>();
        }

        [Fact]
        public async Task GetCategory_WhenCategoryExist_ReturnsSuccessfulState()
        {
            //Arrange
            var categoryId = 1;
            _categoryService.FindByIdAsync(categoryId,default).Returns(new Category());

            var controller = ControllerInstance();

            //Act
            var result = await controller.GetSingleCategory(categoryId,default);

            //Assert
            (result.Result as OkObjectResult).StatusCode.Should().Be(200);
        }
        
        private  CategoryController ControllerInstance() =>
            new(_categoryService);
    }
}
