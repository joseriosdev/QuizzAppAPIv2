using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizApiContext _context;
        public QuizRepository(QuizApiContext context)
        {
            _context = context;
        }

        public async Task<Quize> CreateQuizAsync(Quize newQuiz, CancellationToken cToken)
        {
            await _context.Quizes.AddAsync(newQuiz, cToken);
            await _context.SaveChangesAsync(cToken);
            return newQuiz;
        }

        public async Task<IEnumerable<Quize>> GetAllQuizAsync(CancellationToken cToken)
        {
            var quizes = await _context.Quizes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.MultipleChoiceQuestions)
                .Include(q => q.Questions)
                    .ThenInclude(q => q.FillInBlankQuestions)
                .ToListAsync(cToken);
            return quizes;
        }

        public async Task<Quize> GetQuizByIdAsync(int quizId, CancellationToken cToken)
        {
            Quize? quiz = await _context.Quizes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.MultipleChoiceQuestions)
                .Include(q => q.Questions)
                    .ThenInclude(q => q.FillInBlankQuestions)
                .SingleOrDefaultAsync(q => q.Id == quizId);
            if (quiz == null)
                throw new Exception("Quiz doesn't exits");
            
            return quiz;
        }

        public async Task<Quize> UpdateQuizAsync(Quize quiz, CancellationToken cToken)
        {
            _context.Entry(quiz).State = EntityState.Modified;
            await _context.SaveChangesAsync(cToken);
            return await GetQuizByIdAsync(quiz.Id, cToken);
        }
    }
}
