using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Repositories;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repository.Models;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Services
{
    public class UserDetailsService: IUserDetailsService
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly IMapper _mapper;

        public UserDetailsService(IUserDetailsRepository userDetailsRepository, IMapper mapper)
        {
            this._userDetailsRepository = userDetailsRepository;
            this._mapper = mapper;
        }

        public async Task<List<UserDetailsDTO>> GetAllUserDetails()
        {
            try
            {
                var allUsersDetails = await _userDetailsRepository.GetAllAsync();
                var allUsersDetailsDTOs = _mapper.Map<List<UserDetailsDTO>>(allUsersDetails);

                return allUsersDetailsDTOs;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<UserDetailsDTO>();
            }
    
        }
    
        public async Task<UserDetailsDTO?> GetUserDetailsById(int id)
        {
            try
            {
                var userDetails = await _userDetailsRepository.GetAsync(id);

                if (userDetails == null) return null;
                else
                {
                    var userDetailsDTO = _mapper.Map<UserDetailsDTO>(userDetails);
                    return userDetailsDTO;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<UserDetailsDTO?> GetUserDetailsByUserId(int id)
        {
            try
            {
                var userDetails = await _userDetailsRepository.GetByUserIdAsync(id);

                if (userDetails == null) return null;
                else
                {
                    var userDetailsDTO = _mapper.Map<UserDetailsDTO>(userDetails);
                    return userDetailsDTO;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            } 
        }

        public async Task<UserDetailsDTO?> AddUserDetails(UserDetailsDTO userRoleDTO, int userId)
        {
            try
            {
                var userDetails = _mapper.Map<UserDetails>(userRoleDTO);

                userDetails.UserId = userId;
                var addedUserDetails = await _userDetailsRepository.AddAsync(userDetails);

                if (addedUserDetails == null) return null;
                else
                {
                    var added = _mapper.Map<UserDetailsDTO>(addedUserDetails);
                    return added;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<UserDetailsDTO?> UpdateUserDetails(UserDetailsDTO userDetailsDTO, int id)
        {
            try
            {
                var userDetails = _mapper.Map<UserDetails>(userDetailsDTO);

                var updated = await _userDetailsRepository.UpdateAsync(userDetails, id);

                if (updated == null) return null;
                else
                {
                    var updatedDTO = _mapper.Map<UserDetailsDTO>(updated);
                    return updatedDTO;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteUserDetails(int id)
        {
            try
            {
                return await _userDetailsRepository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
