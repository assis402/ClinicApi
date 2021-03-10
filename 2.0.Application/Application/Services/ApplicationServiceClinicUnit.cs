using Infrastruture.Adapter.Interfaces;
using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Core.Interfaces.Services;

namespace Application.Services
{
    public class ApplicationServiceClinicUnit : IApplicationServiceClinicUnit
    {
        private readonly IClinicUnitMapper clinicUnitMapper;
        private readonly IClinicUnitService clinicUnitService;

        public ApplicationServiceClinicUnit(IClinicUnitMapper clinicUnitMapper, IClinicUnitService clinicUnitService)
        {
            this.clinicUnitMapper = clinicUnitMapper;
            this.clinicUnitService = clinicUnitService;    
        }

        public async Task AddAsync(ClinicUnitDTO clinicUnitDTO)
        {
            ClinicUnit clinicUnit = clinicUnitMapper.MapperToEntity(clinicUnitDTO);
            await clinicUnitService.InsertClinicUnit(clinicUnit);
        }

        public async Task<ClinicUnitDTO> GetByIdAsync(int clinicUnitId)
        {
            ClinicUnit clinicUnit = await clinicUnitService.GetClinicUnitById(clinicUnitId);
            return clinicUnitMapper.MapperToDTO(clinicUnit);
        }
    }
}