using Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Application.DTO;

namespace Domain.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserToLogin(UserDTO userDTO);
    }
}