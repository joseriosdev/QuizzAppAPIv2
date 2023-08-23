using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;

namespace QuizzApp.Ports.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserToDisplayDTO>> FindAllAsync(CancellationToken cToken);
        Task<UserToDisplayDTO> FindByIdAsync(int id, CancellationToken cToken);
        Task<UserToDisplayDTO> UpdateAsync(int id, UserToUpsertDTO userDTO, CancellationToken cToken);
        Task<UserToDisplayDTO> InsertAsync(UserToUpsertDTO userDTO, CancellationToken cToken);
        Task<User> FindDetailedInfoAsync(int id);
        Task DeactivateUserAsync(int id, CancellationToken cToken);
    }
}
