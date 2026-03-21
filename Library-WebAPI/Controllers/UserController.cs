using Library_WebAPI.DTOs.LoanDTOs;
using Library_WebAPI.DTOs.UserDTOs;
using Library_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserListDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if (!users.Any())
                return NoContent();

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDetailsDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDetailsDTO>> CreateUser(UserWriteDTO userCreate)
        {
            var user = await _userService.CreateUserAsync(userCreate);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
