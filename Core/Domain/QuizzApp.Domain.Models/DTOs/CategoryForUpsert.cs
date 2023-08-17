using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuizzApp.Domain.Models.DTOs
{
    public record CategoryForUpsert(int Id, string? Name);
}
