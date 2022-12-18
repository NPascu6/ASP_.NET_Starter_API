using ASP_CORE_BASIC_NET_6_API.CustomAuthorizationAttributes;
using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CORE_BASIC_NET_6_API.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController : Controller
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            this._usersService = usersService;
        }

        [HttpGet]
        [Authorize]
        [UserAuthorization]
        [Route("/GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersService.GetAllUsers();
            return Ok(users);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _usersService.GetById(id);
            if (user == null) return NotFound($"Item with id {id} not found.");
            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        [Route("/AddUser")]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            UserValidators validator = new UserValidators();
            var result = validator.Validate(userDTO);

            if (result.IsValid)
            {
                var user = await _usersService.AddUser(userDTO);
                if (user == null) return NotFound($"Item {userDTO} not added.");
                return Ok(user);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [Authorize]
        [HttpPatch]
        [Route("/UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO, int id)
        {
            UserValidators validator = new UserValidators();
            var result = validator.Validate(userDTO);

            if (result.IsValid)
            {
                var user = await _usersService.UpdateUser(userDTO, id);
                if (user == null) return NotFound($"Item {userDTO} not updated.");
                return Ok(user);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("/DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _usersService.DeleteUser(id);
            if (user == false) return NotFound($"User {id} not found.");
            return Ok(user);
        }

        [Authorize]
        [HttpDelete]
        [Route("/DeleteAllUsers")]
        public async Task<IActionResult> DeleteAllUsers()
        {
            var user = await _usersService.DeleteAllUsers();
            if (user == false) return NotFound($"No user deleted.");
            return Ok(user);
        }
    }
}