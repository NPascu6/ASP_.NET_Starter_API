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

        public List<UserDTO> GetAllUsers()
        {
            var allUsers = _userRepository.GetAll();
            var usersDTO = _mapper.Map<List<UserDTO>>(allUsers);

            return usersDTO;
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userRepository.Get(id);
            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }
    }
}
