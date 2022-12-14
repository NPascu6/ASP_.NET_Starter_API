using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Services;
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
        public async Task<IActionResult> GetAllUserDetails()
        {
            var allUsersDetails = await _userDetailsService.GetAllUserDetails();
            return Ok(allUsersDetails);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetUserDetailsById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userDetail = await _userDetailsService.GetUserDetailsById(id);
            if (userDetail == null) return NotFound($"Item with id {id} not found.");
            return Ok(userDetail);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetUserDetailsByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var userDetail = await _userDetailsService.GetUserDetailsByUserId(id);
            if (userDetail == null) return NotFound($"Item with id {id} not found.");
            return Ok(userDetail);
        }

        [Authorize]
        [HttpPost]
        [Route("/AddUserDetails/{userId}")]
        public async Task<IActionResult> AddUserDetails(UserDetailsDTO userDetailsDTO, int userId)
        {
            var userDetails = await _userDetailsService.AddUserDetails(userDetailsDTO, userId);
            if (userDetails == null) return NotFound($"Item {userDetailsDTO} not added.");
            return Ok(userDetails);
        }

        [Authorize]
        [HttpPatch]
        [Route("/UpdateUserDetails/{id}")]
        public async Task<IActionResult> UpdateUserDetails(UserDetailsDTO userDTO, int id)
        {
            var userDetails = await _userDetailsService.UpdateUserDetails(userDTO, id);
            if (userDetails == null) return NotFound($"Item {userDTO} not updated.");
            return Ok(userDetails);
        }

        [Authorize]
        [HttpDelete]
        [Route("/DeleteUserDetails/{id}")]
        public async Task<IActionResult> DeleteUserDetails(int id)
        {
            var userDetails = await _userDetailsService.DeleteUserDetails(id);
            if (userDetails == false) return NotFound($"User details {id} not found.");
            return Ok(userDetails);
        }
    }
}