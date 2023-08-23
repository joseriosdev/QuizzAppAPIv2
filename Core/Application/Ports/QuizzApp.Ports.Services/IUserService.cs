using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;

namespace QuizzApp.Ports.Services
{
    public interface IUserService
    {
        Task<User> CreateAsync(UserToUpsertDTO userDTO, CancellationToken cToken);
        Task<IEnumerable<UserToDisplayDTO>> FindAllAsync(CancellationToken cToken);
        Task<UserToDisplayDTO?> FindByIdAsync(int id, CancellationToken cToken);
        Task<UserToDisplayDTO> UpdateByIdAsync(int id, UserToUpsertDTO userDTO, CancellationToken cToken);
        Task<User> FindDetailedInfoAsync(int id, CancellationToken cToken);
    }
}
