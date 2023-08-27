using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Ports.Services
{
    public interface IQuizService
    {
        Task<IEnumerable<Quize>> FindAllAsync(
    CancellationToken cancellationToken);
        Task<Quize> FindByIdAsync(
            int id, CancellationToken cancellationToken);
        Task<Quize> CreateAsync(
            QuizForUpsert newQuiz, CancellationToken cancellationToken);
        Task<Quize> UpdatepByIdAsync(
            QuizForUpsert quiz, CancellationToken cancellationToken);
        Task<bool> DeleteByIdAsync(
            int id, CancellationToken cancellationToken);
    }
}
