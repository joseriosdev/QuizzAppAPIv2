using FluentAssertions;
using FluentAssertions.Execution;
using NSubstitute;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Server.Models;
using QuizzApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Test.Services
{
    public class UserServiceTests
    {
            
        private IUserRepository _repository;

        public UserServiceTests()
        {
            _repository = Substitute.For<IUserRepository>();
        }

        [Fact]
        public async Task RetrieveUser_WhenRepositoryReturnsUser_ReturnsUserForDisplay()
        {
            // Arrange
            var userId = 1;
            var userRetrieved = new UserToDisplayDTO() { Id = userId };
            _repository.GetUserByIdAsync(userId, default)
                .ReturnsForAnyArgs(userRetrieved);
            var handler = HandlerInstace();

            // Act
            var result = await handler.FindByIdAsync(userId, default);

            // Assert
            using AssertionScope scope = new();
            result.Should().BeOfType<UserToDisplayDTO>();
            result.Id.Should().Be(userId);
        }

        private UserService HandlerInstace()
            => new(_repository);
    }
}
