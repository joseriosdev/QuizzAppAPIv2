using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Ports.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(CategoryDTO categoryDTO, CancellationToken cToken);
        Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cToken);
        Task<Category?> GetUserByIdAsync(int id, CancellationToken cToken);
        Task<Category> UpdateUserByIdAsync(int id, CategoryDTO categoryDTO, CancellationToken cToken);
        Task<bool> DeleteUserByIdAsync(int id, CancellationToken cToken);
    }
}
