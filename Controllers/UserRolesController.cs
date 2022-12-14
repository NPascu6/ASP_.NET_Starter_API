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
        public IActionResult GetAll()
        {
            var userRoles = _userRolesService.GetAllUserRoles();

            return Ok(userRoles);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetUserRoleById/{id}")]
        public IActionResult Get(int id)
        {
            var userRole = _userRolesService.GetUserRoleById(id);
            if(userRole == null) return NotFound($"Item with id {id} not found."); ;
            return Ok(userRole);
        }
    }
}
