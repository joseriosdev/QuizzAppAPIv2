using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Domain.Models.DTOs
{
    public class QuizToCreateDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreatedByEmail { get; set; }
    }
}
