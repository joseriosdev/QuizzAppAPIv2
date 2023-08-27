using QuizzApp.Ports.Services;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Services
{
    public class QuestionService : IQuestionService
    {
        public Task<Question> DeleteQuestion(int quizId, int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Question> RetrieveQuestion(int quizId, int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> RetrieveQuestions(int quizId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
