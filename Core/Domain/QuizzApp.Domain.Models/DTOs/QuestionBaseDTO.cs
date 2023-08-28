using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Domain.Models.DTOs
{
    public class QuestionBaseDTO
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? CorrectAnswer { get; set; }
        public int? Score { get; set; }
        public int? QuizId { get; set; }
    }
}
