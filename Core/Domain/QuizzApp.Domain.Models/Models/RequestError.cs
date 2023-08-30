using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Domain.Models.Models
{
    public record RequestError(HttpStatusCode StatusCode, string Message);
}
