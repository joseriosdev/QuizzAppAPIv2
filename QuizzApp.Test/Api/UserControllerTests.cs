using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using QuizzApp.Api.Rest.Controllers;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Services;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Test.Controllers
{
    public class UserControllerTests
    {
        private readonly IUserService _userService;

        public UserControllerTests()
        {
            _userService = Substitute.For<IUserService>();
        }

        [Fact]
        public async Task GetUser_WhenUserExist_ReturnsSuccessfulState()
        {
            //Arrange
            var userId = 1;
            _userService.FindByIdAsync(userId, default).Returns(new UserToDisplayDTO());

            var controller = ControllerInstance();

            //Act
            var result = await controller.GetSingleUser(userId, default);

            //Assert
            (result.Result as OkObjectResult).StatusCode.Should().Be(200);
        }

        private UserController ControllerInstance() =>
            new(_userService);
    }
}
