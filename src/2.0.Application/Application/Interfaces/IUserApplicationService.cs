using Application.DTO;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserApplicationService
    {
         Task<UserDTO> GetUserToLogin(UserDTO userDTO);
    }
}