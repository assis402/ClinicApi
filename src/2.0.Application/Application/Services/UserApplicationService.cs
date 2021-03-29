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

        public async Task<UserDTO> GetUserToLogin(int clinicalUnitId, string taxNumber, string password)
        {
            User User = await UserService.GetUserToLogin(taxNumber, password);
            return UserMapper.MapperToDTO(User);
        }
    }
}