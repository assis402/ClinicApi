using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core.Interfaces.Services
{
    public interface IClinicUnitService
    {
        Task<string> InsertClinicUnit(ClinicUnit clinicUnit);

        //Task<string> UpdateClinicUnit(ClinicUnit clinicUnit);

        Task<ClinicUnit> GetClinicUnitById(int clinicUnitId);

        //Task<string> DeleteClinicUnitById(int id);
    }
}