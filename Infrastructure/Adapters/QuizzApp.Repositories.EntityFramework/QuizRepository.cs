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
            var quizes = await _context.Quizes.ToListAsync(cToken);
            return quizes;
        }
    }
}
