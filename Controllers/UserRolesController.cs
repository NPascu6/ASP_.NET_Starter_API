using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Services;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CORE_BASIC_NET_6_API.Controllers
{
    [ApiController]
    [Route("Users Roles")]
    public class UserRolesController : Controller
    {
        private readonly IUserRolesService _userRolesService;

        public UserRolesController(IUserRolesService userRolesService)
        {
            this._userRolesService = userRolesService;
        }

        [Authorize]
        [HttpGet]
        [Route("/GetAllUserRoles")]
        public async Task<IActionResult> GetAll()
        {
            var userRoles = await _userRolesService.GetAllUserRoles();

            return Ok(userRoles);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetUserRoleById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userRole =  await _userRolesService.GetUserRoleById(id);
            if(userRole == null) return NotFound($"Item with id {id} not found."); ;
            return Ok(userRole);
        }

        [Authorize]
        [HttpPost]
        [Route("/AddUserRole")]
        public async Task<IActionResult> AddUserRole(UserRoleDTO userRoleDTO)
        {
            var userRole = await _userRolesService.AddUserRole(userRoleDTO);
            if (userRole == null) return NotFound($"Item {userRoleDTO} not added.");
            return Ok(userRole);
        }

        [Authorize]
        [HttpPatch]
        [Route("/UpdateUserRole/{id}")]
        public async Task<IActionResult> UpdateUserRole(UserRoleDTO userRoleDTO, int id)
        {
            var userRole = await _userRolesService.UpdateUserRole(userRoleDTO, id);
            if (userRole == null) return NotFound($"Item {userRoleDTO} not updated.");
            return Ok(userRole);
        }

        [Authorize]
        [HttpDelete]
        [Route("/DeleteUserRole/{id}")]
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            var userRole = await _userRolesService.DeleteUserRole(id);
            if (userRole == false) return NotFound($"User role {id} not found.");
            return Ok(userRole);
        }
    }
}
