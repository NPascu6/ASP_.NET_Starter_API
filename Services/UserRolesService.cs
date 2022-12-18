using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Repositories;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repository.Models;
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

        public async Task<List<UserRoleDTO>> GetAllUserRoles()
        {
            try
            {
                var allRoles = await _userRolesRepository.GetAllAsync();
                var allRolesDTOs = _mapper.Map<List<UserRoleDTO>>(allRoles);

                return allRolesDTOs;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return new List<UserRoleDTO>();
            }
        
        }

        public async Task<UserRoleDTO?> GetUserRoleById(int id)
        {
            var userRole =  await _userRolesRepository.GetAsync(id);
            if (userRole == null) return null;
            else
            {
                var roleDTO = _mapper.Map<UserRoleDTO>(userRole);
                return roleDTO;
            }
        }

        public async Task<UserRoleDTO?> AddUserRole(UserRoleDTO userRoleDTO)
        {
            try
            {
                var userRole = _mapper.Map<UserRole>(userRoleDTO);

                var addedUserRole = await _userRolesRepository.AddAsync(userRole);

                if (addedUserRole == null) return null;
                else
                {
                    var added = _mapper.Map<UserRoleDTO>(addedUserRole);
                    return added;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<UserRoleDTO?> UpdateUserRole(UserRoleDTO userRoleDTO, int id)
        {
            try
            {
                var userRole = _mapper.Map<UserRole>(userRoleDTO);

                var updated = await _userRolesRepository.UpdateAsync(userRole, id);

                if (updated == null) return null;
                else
                {
                    var updatedDTO = _mapper.Map<UserRoleDTO>(updated);
                    return updatedDTO;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteUserRole(int id)
        {
            try
            {
                return await _userRolesRepository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> DeleteAllUserRoles()
        {
            try
            {
                return await _userRolesRepository.DeleteAllAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
