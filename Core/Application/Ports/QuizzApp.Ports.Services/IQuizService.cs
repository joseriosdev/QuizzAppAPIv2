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
        Task<Quize> CreateDraftAsync(QuizToCreateDTO newQuiz, CancellationToken cToken);
        Task<Quize> AddMultipleChoiceQuestionAsync(
            int quizId, MultipleChoiceQuestionDTO question, CancellationToken cToken);
        Task<Quize> AddFillInQuestionAsync(
            int quizId, FillInQuestionDTO question, CancellationToken cToken);
    }
}
