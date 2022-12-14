﻿using ASP_CORE_BASIC_NET_6_API.Models.DTOs;

namespace ASP_CORE_BASIC_NET_6_API.Services.Interfaces
{
    public interface IUsersService
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO?> GetById(int id);
        Task<UserDTO?> AddUser(UserDTO userDTO);
    }
}
