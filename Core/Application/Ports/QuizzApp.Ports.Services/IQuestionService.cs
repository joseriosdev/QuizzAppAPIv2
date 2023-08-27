using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Ports.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> RetrieveQuestions(
    int quizId, CancellationToken cancellationToken);
        Task<Question> RetrieveQuestion(
            int quizId, int id, CancellationToken cancellationToken);
        Task<Question> DeleteQuestion(
            int quizId, int id, CancellationToken cancellationToken);
    }
}
