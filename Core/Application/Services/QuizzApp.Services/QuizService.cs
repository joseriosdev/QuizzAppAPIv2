using AutoMapper;
using Microsoft.Identity.Client;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Ports.Services;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public QuizService(IQuizRepository quizRepo, IUserRepository userRepo, IMapper mapper)
        {
            _quizRepository = quizRepo;
            _userRepository = userRepo;
            _mapper = mapper;
        }

        public async Task<Quize> CreateAsync(QuizToCreateDTO newQuiz, CancellationToken cToken)
        {
            User? createdByUser = await _userRepository.GetWholeUserByEmailAsync(newQuiz.CreatedByEmail);
            if (createdByUser == null)
                throw new Exception("Invalid user creator");
            
            Quize quizToCreate = _mapper.Map<Quize>(newQuiz);
            quizToCreate.CreatedAt = DateTime.UtcNow;
            quizToCreate.CreatedBy = createdByUser.Id;
            return await _quizRepository.CreateQuizAsync(quizToCreate, cToken);
        }

        public async Task<IEnumerable<Quize>> FindAllAsync(CancellationToken cToken)
        {
            return await _quizRepository.GetAllQuizAsync(cToken);
        }
    }
}
