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
        Task<UserToDisplayDTO> UpdateUserAsync(int id, UserToUpsertDTO userDTO, CancellationToken cToken);
        Task<UserToDisplayDTO> InsertUserAsync(UserToUpsertDTO userDTO, CancellationToken cToken);
        Task<IEnumerable<UserToDisplayDTO>> GetAllUsersAsync(CancellationToken cToken);
        Task<UserToDisplayDTO> GetUserByIdAsync(int id, CancellationToken cToken);
        Task<User> GetWholeUserByIdAsync(int id);
        Task UpdateWholeUserByIdAsync(int id, User user);
        Task<bool> DeleteUserByIdAsync(int id, CancellationToken cToken);
    }
}
