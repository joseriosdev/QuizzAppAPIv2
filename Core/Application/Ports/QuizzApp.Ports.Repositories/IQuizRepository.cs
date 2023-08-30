using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Ports.Repositories
{
    public interface IQuizRepository
    {
        Task<Quize> CreateQuizAsync(Quize quizDto, CancellationToken cToken);
        Task<IEnumerable<Quize>> GetAllQuizAsync(CancellationToken cToken);
        Task<Quize> GetQuizByIdAsync(int quizId, CancellationToken cToken);
        Task<Quize> UpdateQuizAsync(Quize quiz, CancellationToken cToken);
    }
}
