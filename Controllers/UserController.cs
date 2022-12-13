using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
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
        [Route("/GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _usersService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("/GetUserById/{id}")]
        public IActionResult Get(int id)
        {
            var users = _usersService.GetUserById(id);
            return Ok(users);
        }
    }
}