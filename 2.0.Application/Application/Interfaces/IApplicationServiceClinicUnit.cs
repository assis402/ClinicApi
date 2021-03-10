using Application.DTO;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceClinicUnit
    {
         Task AddAsync(ClinicUnitDTO clinicUnitDTO);

         Task<ClinicUnitDTO> GetByIdAsync(int clinicUnitId);
    }
}