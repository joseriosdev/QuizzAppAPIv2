using AutoMapper;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Repositories.EntityFramework.ProfileMappers
{
    public class QuestionMapper : Profile
    {
        public QuestionMapper()
        {
            CreateMap<Question, QuestionBaseDTO>();
            CreateMap<QuestionBaseDTO, Question>();
            CreateMap<MultipleChoiceQuestion, MultipleChoiceQuestionDTO>()
                .IncludeBase<Question, QuestionBaseDTO>()
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src =>
                    new string[] { src.Value1, src.Value2, src.Value3, src.Value4 }));
            CreateMap<MultipleChoiceQuestionDTO, MultipleChoiceQuestion>();
        }
    }
}
