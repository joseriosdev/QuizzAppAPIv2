using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Ports.Services;
using QuizzApp.Server.Models;
using QuizzApp.Services.ExtensionMethods;
using QuizzApp.Services.Validations;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<UserToDisplayDTO> UpdateAsync(int id, UserToUpsertDTO userDTO, CancellationToken cToken)
        {
            ValidateUser(userDTO);
            userDTO = await ValidateUserPasswordChanged(userDTO, id);
            return await _userRepository.UpdateUserAsync(id, userDTO, cToken);
        }

        public async Task<UserToDisplayDTO> InsertAsync(UserToUpsertDTO userDTO, CancellationToken cToken)
        {
            ValidateUser(userDTO);
            userDTO.Password = userDTO.Password!.GetSha256();
            return await _userRepository.InsertUserAsync(userDTO, cToken);
        }

        public async Task<IEnumerable<UserToDisplayDTO>> FindAllAsync(CancellationToken cToken)
        {
            return await _userRepository.GetAllUsersAsync(cToken);
        }

        public async Task<UserToDisplayDTO> FindByIdAsync(int id, CancellationToken cToken)
        {
            return await _userRepository.GetUserByIdAsync(id, cToken);
        }

        public async Task<User> FindDetailedInfoAsync(int id)
        {
            return await _userRepository.GetWholeUserByIdAsync(id);
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken cToken)
        {
            bool result = await _userRepository.DeleteUserByIdAsync(id, cToken);
            return result;
        }


        private void ValidateUser(UserToUpsertDTO user)
        {
            UserValidator uValidator = new();
            uValidator.ValidateAndThrow(user);
        }

        private async Task<UserToUpsertDTO> ValidateUserPasswordChanged(UserToUpsertDTO userDto, int id)
        {
            User userDB = await FindDetailedInfoAsync(id);
            if(userDB.Password == userDto.Password)
            {
                return userDto;
            }
            else
            {
                userDto.Password = userDto.Password!.GetSha256();
                return userDto;
            }
        }
    }
}
