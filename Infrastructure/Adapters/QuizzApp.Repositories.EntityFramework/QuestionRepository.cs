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
        private readonly QuizApiContext _context;
        public QuestionRepository(QuizApiContext context)
        {
            _context = context;
        }

        public async Task<Question> CreateMultipleChoiceQuestionAsync(
            Question multiQuestion, MultipleChoiceQuestion choices, CancellationToken cToken)
        {
            await _context.Questions.AddAsync(multiQuestion, cToken);
            await _context.MultipleChoiceQuestions.AddAsync(choices, cToken);

            choices.QuestionId = multiQuestion.Id;
            multiQuestion.MultipleChoiceQuestions.Add(choices);

            await _context.SaveChangesAsync(cToken);
            return multiQuestion;
        }

        public Task<Question> CreateQuestionAsync(QuestionToCreateDTO questionDto, CancellationToken cToken)
        {
            return null;
        }

        public async Task<Question> CreateFillInQuestionAsync(
            Question fillInQuestion, FillInBlankQuestion blankSpace,
            CancellationToken cToken)
        {
            await _context.Questions.AddAsync(fillInQuestion, cToken);
            await _context.SaveChangesAsync(cToken);

            blankSpace.QuestionId = fillInQuestion.Id;

            await _context.FillInBlankQuestions.AddAsync(blankSpace, cToken);
            await _context.SaveChangesAsync(cToken);
            return fillInQuestion;
        }
    }
}
