using System.Threading.Tasks;
using ClinicApi.Domain.Entities;

namespace ClinicApi.Domain.Core.Interfaces.Services
{
    public interface IClinicUnitService
    {
        Task<string> InsertClinicUnit(ClinicUnit clinicUnit);

        Task<ClinicUnit> GetClinicUnitById(int id);

        Task<string> UpdateClinicUnit(ClinicUnit clinicUnit);

        Task<string> DeleteClinicUnitById(int id);
    }
}