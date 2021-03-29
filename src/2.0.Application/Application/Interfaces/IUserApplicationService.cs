using Application.DTO;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserApplicationService
    {
         Task<ClinicalUnitDTO> GetUserToLogin(int clinicalUnitId, string taxNumber, string password);
    }
}