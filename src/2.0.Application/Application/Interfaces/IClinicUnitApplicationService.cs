using Application.DTO;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClinicUnitApplicationService
    {
         Task InsertClinicUnit(ClinicUnitDTO clinicUnitDTO);

         Task<ClinicUnitDTO> GetClinicUnitById(int clinicUnitId);
    }
}