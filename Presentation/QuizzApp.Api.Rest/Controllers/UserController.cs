using Microsoft.AspNetCore.Mvc;
using QuizzApp.Domain.Models.DTOs;
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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken cToken)
        {
            var users = await _userService.FindAllAsync(cToken);
            if(users.Count() == 0)
                return Ok("User's list is empty");

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleUser(int id, CancellationToken cToken)
        {
            var user = await _userService.FindByIdAsync(id, cToken);
            if (user is null)
                return NoContent();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserToUpsertDTO userDto, CancellationToken cToken)
        {
            var userInserted = await _userService.InsertAsync(userDto, cToken);
            return Ok(userInserted);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromBody] UserToUpsertDTO userDto, int id, CancellationToken cToken)
        {
            var insertedUser = await _userService.UpdateAsync(id, userDto, cToken);
            return Ok(insertedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken cToken)
        {
            bool result = await _userService.DeleteUserAsync(id, cToken);
            return Ok(result);
        }
    }
}
