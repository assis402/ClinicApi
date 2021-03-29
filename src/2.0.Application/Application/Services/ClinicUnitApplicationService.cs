using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Core.Interfaces.Services;
using Infrastructure.Adapter.Interfaces;

namespace Application.Services
{
    public class ClinicalUnitApplicationService : IClinicalUnitApplicationService
    {
        private readonly IClinicalUnitMapper ClinicalUnitMapper;
        private readonly IClinicalUnitService ClinicalUnitService;

        public ClinicalUnitApplicationService(IClinicalUnitMapper ClinicalUnitMapper, IClinicalUnitService ClinicalUnitService)
        {
            this.ClinicalUnitMapper = ClinicalUnitMapper;
            this.ClinicalUnitService = ClinicalUnitService;    
        }

        public async Task<ClinicalUnitDTO> InsertClinicalUnit(ClinicalUnitDTO ClinicalUnitDTO)
        {
            ClinicalUnit ClinicalUnit = ClinicalUnitMapper.MapperToEntity(ClinicalUnitDTO);
            ClinicalUnit = await ClinicalUnitService.InsertClinicalUnit(ClinicalUnit);
            return ClinicalUnitMapper.MapperToDTO(ClinicalUnit);
        }

        public async Task<ClinicalUnitDTO> GetClinicalUnitById(int ClinicalUnitId)
        {
            ClinicalUnit ClinicalUnit = await ClinicalUnitService.GetClinicalUnitById(ClinicalUnitId);
            return ClinicalUnitMapper.MapperToDTO(ClinicalUnit);
        }
    }
}