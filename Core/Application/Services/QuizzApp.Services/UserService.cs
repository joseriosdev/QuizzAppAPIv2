using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Ports.Services;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        public Task<User> CreateAsync(UserToUpsertDTO userDTO, CancellationToken cToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserToDisplayDTO>> FindAllAsync(CancellationToken cToken)
        {
            throw new NotImplementedException();
        }

        public Task<UserToDisplayDTO?> FindByIdAsync(int id, CancellationToken cToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindDetailedInfoAsync(int id, CancellationToken cToken)
        {
            throw new NotImplementedException();
        }

        public Task<UserToDisplayDTO> UpdateByIdAsync(int id, UserToUpsertDTO userDTO, CancellationToken cToken)
        {
            throw new NotImplementedException();
        }
    }
}
