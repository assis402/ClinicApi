using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Core.Interfaces.Services;
using Infrastructure.Adapter.Interfaces;

namespace Application.Services
{
    public class ClinicUnitApplicationService : IClinicUnitApplicationService
    {
        private readonly IClinicUnitMapper clinicUnitMapper;
        private readonly IClinicUnitService clinicUnitService;

        public ClinicUnitApplicationService(IClinicUnitMapper clinicUnitMapper, IClinicUnitService clinicUnitService)
        {
            this.clinicUnitMapper = clinicUnitMapper;
            this.clinicUnitService = clinicUnitService;    
        }

        public async Task InsertClinicUnit(ClinicUnitDTO clinicUnitDTO)
        {
            ClinicUnit clinicUnit = clinicUnitMapper.MapperToEntity(clinicUnitDTO);
            await clinicUnitService.InsertClinicUnit(clinicUnit);
        }

        public async Task<ClinicUnitDTO> GetClinicUnitById(int clinicUnitId)
        {
            ClinicUnit clinicUnit = await clinicUnitService.GetClinicUnitById(clinicUnitId);
            return clinicUnitMapper.MapperToDTO(clinicUnit);
        }
    }
}