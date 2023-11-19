using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using TrackingApp.Helper;
using TrackingApp.Model;
using TrackingApp.Services.UserService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        // POST api/<CategoryController>
        [HttpGet("id")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userService.Get(id);
            return Ok(user);
        }
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User value, string token)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var users = await _userService.Get();
            var loginUser = users.FirstOrDefault(u => u.UserName == value.UserName);
            if (loginUser == null)
            {
                return NotFound(new
                {
                    Message = "User not Found"
                });
            }
            if (!PasswordHasher.VerifyPassword(value.Password, loginUser.Password))
            {
                return NotFound(new
                {
                    Message = "Password doesn't matched"
                });
            }
            return Ok(new
            {
                Message = "Login Success!",
                token=loginUser.Role,
                user=loginUser.UserName,
                userid=loginUser.Id
            });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User value)
        {
            //username
            if (await CheckUsernameExist(value.UserName))
            {
                return BadRequest(new
                {
                    Message = "Username already exist"
                });
            }

            //email
            if (await CheckEmailExist(value.Email))
            {
                return BadRequest(new
                {
                    Message = "Email already exist"
                });
            }

            //password strength


            value.Password = PasswordHasher.HashPassword(value.Password);
            value.Role = "User";
            await _userService.Post(value);
            return Ok(new
            {
                Message = "User added successfully"
            });
        }

        private async Task<bool> CheckUsernameExist(string username)
        {
            var users = await _userService.Get();
            var user = users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        private async Task<bool> CheckEmailExist(string email)
        {
            var users = await _userService.Get();
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
