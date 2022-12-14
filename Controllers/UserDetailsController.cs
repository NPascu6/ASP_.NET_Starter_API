using ASP_CORE_BASIC_NET_6_API.Models.Domain;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        [Route("/GetAllUserDetails")]
        public IActionResult GetAllUserDetails()
        {
            var allUsersDetails = _userDetailsService.GetAllUserDetails();
            return Ok(allUsersDetails);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetUserDetailsById/{id}")]
        public IActionResult Get(int id)
        {
            var userDetail = _userDetailsService.GetUserDetailsById(id);
            if (userDetail == null) return NotFound($"Item with id {id} not found.");
            return Ok(userDetail);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetUserDetailsByUserId/{id}")]
        public IActionResult GetByUserId(int id)
        {
            var userDetail = _userDetailsService.GetUserDetailsByUserId(id);
            if (userDetail == null) return NotFound($"Item with id {id} not found.");
            return Ok(userDetail);
        }
    }
}