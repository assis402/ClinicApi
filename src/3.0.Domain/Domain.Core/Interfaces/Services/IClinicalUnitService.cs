using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core.Interfaces.Services
{
    public interface IClinicalUnitService
    {
        Task<ClinicalUnit> InsertClinicalUnit(ClinicalUnit ClinicalUnit);

        //Task<string> UpdateClinicalUnit(ClinicalUnit ClinicalUnit);

        Task<ClinicalUnit> GetClinicalUnitById(int ClinicalUnitId);

        //Task<string> DeleteClinicalUnitById(int id);
    }
}