using AutoMapper;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Ports.Repositories;
using QuizzApp.Ports.Services;
using QuizzApp.Repositories.EntityFramework.ProfileMappers;
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
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _quizMapper;
        private readonly IMapper _questionMapper;

        public QuizService(
            IQuizRepository quizRepo, IUserRepository userRepo,
            IQuestionRepository questionRepo, IMapper quizMapper,
            IMapper questionMapper
            )
        {
            _quizRepository = quizRepo;
            _userRepository = userRepo;
            _questionRepository = questionRepo;
            _quizMapper = quizMapper;
            _questionMapper = questionMapper;
        }

        public async Task<Quize> CreateDraftAsync(QuizToCreateDTO newQuiz, CancellationToken cToken)
        {
            User? createdByUser = await _userRepository.GetWholeUserByEmailAsync(newQuiz.CreatedByEmail);
            if (createdByUser == null)
                throw new Exception("Invalid user creator");
            
            Quize quizToCreate = _quizMapper.Map<Quize>(newQuiz);
            quizToCreate.CreatedAt = DateTime.UtcNow;
            quizToCreate.CreatedBy = createdByUser.Id;
            return await _quizRepository.CreateQuizAsync(quizToCreate, cToken);
        }

        public async Task<IEnumerable<Quize>> FindAllAsync(CancellationToken cToken)
        {
            return await _quizRepository.GetAllQuizAsync(cToken);
        }

        public async Task<Quize> AddMultipleChoiceQuestionAsync(
            int quizId, MultipleChoiceQuestionDTO question, CancellationToken cToken
            )
        {
            ValidateMultipleChoiceArray(question.Choices!);
            var (questionToInsert, multipleChoices) = 
                QuestionManualMapper.MapMultipleDTOToQuestion(question);
            questionToInsert.QuizId = quizId;
            questionToInsert.CreatedAt = DateTime.UtcNow;

            await _questionRepository
                .CreateMultipleChoiceQuestionAsync(questionToInsert, multipleChoices, cToken);
            Quize actualQuiz = await _quizRepository.GetQuizByIdAsync(quizId, cToken);
            return actualQuiz;
        }

        public async Task<Quize> AddFillInQuestionAsync(
            int quizId, FillInQuestionDTO question, CancellationToken cToken)
        {
            var (questionToInsert, fillInQuestion) =
                QuestionManualMapper.MapFillInDTOToQuestion(question);
            questionToInsert.QuizId = quizId;
            questionToInsert.CreatedAt = DateTime.UtcNow;

            await _questionRepository
                .CreateFillInQuestionAsync(questionToInsert, fillInQuestion, cToken);
            Quize actualQuiz = await _quizRepository.GetQuizByIdAsync(quizId, cToken);
            return actualQuiz;
        }

        private void ValidateMultipleChoiceArray(string[] arr)
        {
            const int MAX = 4;
            const int MIN = 0;

            if ( !(arr.Length > MIN && arr.Length == MAX) )
                throw new Exception("Invalid Amount of Choices, should be 4");
            
            for(int i = 0; i != arr.Length; i++)
            {
                if (arr[i].IsNullOrEmpty())
                    throw new Exception("All 4 choices should have content");
            }
        }
    }
}
