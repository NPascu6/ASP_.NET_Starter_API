using ASP_CORE_BASIC_NET_6_API.Services;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CORE_BASIC_NET_6_API.Controllers
{
    [ApiController]
    [Route("Users Details")]
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailsService _userDetailsService;

        public UserDetailsController(IUserDetailsService userDetailsService)
        {
            this._userDetailsService = userDetailsService;
        }

        [HttpGet]
        [Route("/GetAllUserDetails")]
        public IActionResult GetAllUserDetails()
        {
            var users = _userDetailsService.GetAllUserDetails();
            return Ok(users);
        }

        [HttpGet]
        [Route("/GetUserDetailsById/{id}")]
        public IActionResult Get(int id)
        {
            var users = _userDetailsService.GetUserDetailsById(id);
            return Ok(users);
        }

        [HttpGet]
        [Route("/GetUserDetailsByUserId/{id}")]
        public IActionResult GetByUserId(int id)
        {
            var users = _userDetailsService.GetUserDetailsByUserId(id);
            return Ok(users);
        }
    }
}