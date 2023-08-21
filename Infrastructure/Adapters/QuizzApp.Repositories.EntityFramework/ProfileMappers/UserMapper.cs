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
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserToDisplayDTO, User>();
            CreateMap<User, UserToDisplayDTO>();
            CreateMap<UserToUpsertDTO, User>();
            CreateMap<User, UserToUpsertDTO>();
        }
    }
}
