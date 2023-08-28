using QuizzApp.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Domain.Models.DTOs
{
    public class QuestionToCreateDTO
    {
        public string? Name { get; set; }
        public string? CorrectAnswer { get; set; }
        public int Score { get; set; }
        public QuestionType Type { get; set; }
    }
}
