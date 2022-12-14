using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
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

        [Authorize]
        [HttpGet]
        [Route("/GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _usersService.GetAllUsers();
            return Ok(users);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetUserById/{id}")]
        public IActionResult Get(int id)
        {
            var user = _usersService.GetUserById(id);
            if (user == null) return NotFound($"Item with id {id} not found.");
            return Ok(user);
        }
    }
}