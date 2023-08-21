using Microsoft.AspNetCore.Mvc;
using QuizzApp.Ports.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp.Api.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            ArgumentNullException.ThrowIfNull(userService);
            _userService = userService;
        }
    }
}
