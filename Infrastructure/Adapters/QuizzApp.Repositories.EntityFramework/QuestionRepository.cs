using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Repositories.EntityFramework
{
    public class QuestionRepository : IQuestionRepository
    {
        public Task<Question> CreateMultipleChoiceQuestionAsync(MultipleChoiceQuestionDTO multiQuestion)
        {
            return null;
        }

        public Task<Question> CreateQuestionAsync(QuestionToCreateDTO questionDto, CancellationToken cToken)
        {
            return null;
        }

        public Task<Question> CreateQuizAsync(QuestionToCreateDTO questionDto, CancellationToken cToken)
        {
            throw new NotImplementedException();
        }
    }
}
