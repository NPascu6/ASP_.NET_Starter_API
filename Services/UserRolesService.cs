using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Services
{
    public class UserRolesService : IUserRolesService
    {
        private readonly IUserRoleRepository _userRolesRepository;
        private readonly IMapper _mapper;

        public UserRolesService(IUserRoleRepository userRolesRepository, IMapper mapper)
        {
            this._userRolesRepository = userRolesRepository;
            this._mapper = mapper;
        }

        public List<UserRoleDTO> GetAllUserRoles()
        {
            var allRoles = _userRolesRepository.GetAll();
            var allRolesDTOs = _mapper.Map<List<UserRoleDTO>>(allRoles);

            return allRolesDTOs;
        }

        public UserRoleDTO GetUserRoleById(int id)
        {
            var userRole = _userRolesRepository.Get(id);
            var roleDTO = _mapper.Map<UserRoleDTO>(userRole);

            return roleDTO;
        }
    }
}
