using ASP_CORE_BASIC_NET_6_API.Services;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
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


        [HttpGet]
        [Route("/GetAllUserRoles")]
        public IActionResult GetAll()
        {
            var userRoles = _userRolesService.GetAllUserRoles();

            return Ok(userRoles);
        }

        [HttpGet]
        [Route("/GetUserRoleById/{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRolesService.GetUserRoleById(id);
            return Ok(user);
        }
    }
}
