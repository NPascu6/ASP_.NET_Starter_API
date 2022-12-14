using ASP_CORE_BASIC_NET_6_API.Models.Domain;
using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersService(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                var allUsers = await _userRepository.GetAllAsync();
                var usersDTO = _mapper.Map<List<UserDTO>>(allUsers);

                return usersDTO;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<UserDTO>();
            }
        }

        public async Task<UserDTO?> GetById(int id)
        {
            try
            {
                var user = await _userRepository.GetAsync(id);

                if (user == null) return null;
                else
                {
                    var userDTO = _mapper.Map<UserDTO>(user);
                    return userDTO;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<UserDTO?> AddUser(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);

                var addedUser = await _userRepository.AddAsync(user);

                if (addedUser == null) return null;
                else
                {
                    var added = _mapper.Map<UserDTO>(addedUser);
                    return added;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<UserDTO?> UpdateUser(UserDTO userDTO, int id)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);

                var addedUser = await _userRepository.UpdateAsync(user, id);

                if (addedUser == null) return null;
                else
                {
                    var added = _mapper.Map<UserDTO>(addedUser);
                    return added;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                return await _userRepository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
