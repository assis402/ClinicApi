using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Core.Interfaces.Services;
using Infrastructure.Adapter.Interfaces;

namespace Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserMapper UserMapper;
        private readonly IUserService UserService;

        public UserApplicationService(IUserMapper UserMapper, IUserService UserService)
        {
            this.UserMapper = UserMapper;
            this.UserService = UserService;    
        }

        public async Task<UserDTO> GetUserToLogin(UserDTO userDTO)
        {
            User user = await UserService.GetUserToLogin(userDTO);
            if (user == null)
                return null;
            return UserMapper.MapperToDTO(user);
        }
    }
}