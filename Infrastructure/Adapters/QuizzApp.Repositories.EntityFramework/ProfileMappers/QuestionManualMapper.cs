using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Repositories.EntityFramework.ProfileMappers
{
    public static class QuestionManualMapper
    {
        public static (Question, MultipleChoiceQuestion) MapMultipleDTOToQuestion(
            MultipleChoiceQuestionDTO qDto)
        {
            var question = new Question();
            var mCQuestion = new MultipleChoiceQuestion
            {
                Value1 = qDto.Choices![0],
                Value2 = qDto.Choices![1],
                Value3 = qDto.Choices![2],
                Value4 = qDto.Choices![3]
            };

            question.Name = qDto.Name;
            question.Type = qDto.Type;
            question.CorrectAnswer = qDto.CorrectAnswer;
            question.Score = qDto.Score;
            question.QuizId = qDto.QuizId;

            return (question, mCQuestion);
        }

        public static (Question,FillInBlankQuestion) MapFillInDTOToQuestion(
            FillInQuestionDTO qDto
            )
        {
            var question = new Question();
            var fIBQuestion = new FillInBlankQuestion();
            question.Name = qDto.Name;
            question.Type = qDto.Type;
            question.CorrectAnswer = qDto.CorrectAnswer;
            question.Score = qDto.Score;
            question.QuizId = qDto.QuizId;
            fIBQuestion.WordPosition = qDto.WordPosition;
            return (question, fIBQuestion);
        }
    }
}
