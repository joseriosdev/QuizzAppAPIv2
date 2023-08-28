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
        Task<IEnumerable<Quize>> FindAllAsync(CancellationToken cToken);
        /*Task<Quize> FindByIdAsync(
            int id, CancellationToken cancellationToken);*/
        Task<Quize> CreateAsync(QuizToCreateDTO newQuiz, CancellationToken cToken);
        /*Task<Quize> UpdatepByIdAsync(
            QuizToCreateDTO quiz, CancellationToken cancellationToken);
        Task<bool> DeleteByIdAsync(
            int id, CancellationToken cancellationToken);*/
    }
}
