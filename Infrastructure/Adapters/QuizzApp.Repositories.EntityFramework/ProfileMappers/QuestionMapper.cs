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
            CreateMap<QuestionToCreateDTO, Question>();
        }
    }
}
