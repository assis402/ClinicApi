using Application.DTO;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClinicalUnitApplicationService
    {
         Task<ClinicalUnitDTO> InsertClinicalUnit(ClinicalUnitDTO ClinicalUnitDTO);

         Task<ClinicalUnitDTO> GetClinicalUnitById(int ClinicalUnitId);
    }
}