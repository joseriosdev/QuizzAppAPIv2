using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Repositories.EntityFramework
{
    public class UserRepository : IUserRepository
    {
        private readonly QuizApiContext _context;
        private readonly IMapper _mapper;

        public UserRepository(QuizApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteUserByIdAsync(int id, CancellationToken cToken)
        {
            User? userFound = await _context.Users.FindAsync(id, cToken);
            if (userFound == null)
            {
                return false;
            }
            _context.Users.Remove(userFound);
            await _context.SaveChangesAsync(cToken);
            return true;
        }

        public async Task<IEnumerable<UserToDisplayDTO>> GetAllUsersAsync(CancellationToken cToken)
        {
            var usersDB = await _context.Users.ToListAsync(cToken);
            var usersDtos = _mapper.Map<List<UserToDisplayDTO>>(usersDB);
            return usersDtos;
        }

        public async Task<UserToDisplayDTO?> GetUserByIdAsync(int id, CancellationToken cToken)
        {
            User? userDB = await _context.Users.FindAsync(id, cToken);
            UserToDisplayDTO userDto = _mapper.Map<UserToDisplayDTO>(userDB);
            return userDto;
        }

        public async Task<User?> GetWholeUserByIdAsync(int id, CancellationToken cToken)
        {
            User? userDB = await _context.Users.FindAsync(id, cToken);
            return userDB;
        }

        public async Task<UserToDisplayDTO> UpsertUserAsync(int id, UserToUpsertDTO userDTO, CancellationToken cToken)
        {
            User? userDB = await _context.Users.FindAsync(id, cToken);

            if (userDB == null)
            {
                User userToCreate = _mapper.Map<User>(userDTO);
                userToCreate.IsActive = true;
                userToCreate.CreatedAt = DateTime.UtcNow;
                await _context.Users.AddAsync(userToCreate, cToken);
                await _context.SaveChangesAsync(cToken);
                UserToDisplayDTO userToDisplay = _mapper.Map<UserToDisplayDTO>(userDB);
                return userToDisplay;
            }
            else
            {
                userDB.Name = userDTO.Name;
                userDB.Email = userDTO.Email;
                userDB.Password = userDTO.Password;
                _context.Entry(userDB).State = EntityState.Modified;
                await _context.SaveChangesAsync(cToken);
                UserToDisplayDTO userToDisplay = _mapper.Map<UserToDisplayDTO>(userDB);
                return userToDisplay;
            }
        }
    }
}
