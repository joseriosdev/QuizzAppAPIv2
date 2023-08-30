using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Ports.Repositories
{
    public interface IQuestionRepository
    {
        Task<Question> CreateQuestionAsync(
            QuestionToCreateDTO questionDto, CancellationToken cToken);
        Task<Question> CreateMultipleChoiceQuestionAsync(
            Question multiQuestion, MultipleChoiceQuestion choices,
            CancellationToken cToken);
        Task<Question> CreateFillInQuestionAsync(
            Question fillInQuestion, FillInBlankQuestion blankSpace,
            CancellationToken cToken);
    }
}
