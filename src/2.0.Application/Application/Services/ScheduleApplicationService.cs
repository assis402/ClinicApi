using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Core.Interfaces.Services;
using Infrastructure.Adapter.Interfaces;

namespace Application.Services
{
    public class ScheduleApplicationService : IScheduleApplicationService
    {
        private readonly IScheduleMapper ScheduleMapper;
        private readonly IScheduleService ScheduleService;

        public ScheduleApplicationService(IScheduleMapper ScheduleMapper, IScheduleService ScheduleService)
        {
            this.ScheduleMapper = ScheduleMapper;
            this.ScheduleService = ScheduleService;    
        }

        public async Task<ScheduleDTO> InsertSchedule(ScheduleDTO ScheduleDTO)
        {
            Schedule Schedule = ScheduleMapper.MapperToEntity(ScheduleDTO);
            Schedule = await ScheduleService.InsertSchedule(Schedule);
            return ScheduleMapper.MapperToDTO(Schedule);
        }

        public async Task<ScheduleDTO> GetScheduleById(int ScheduleId)
        {
            Schedule Schedule = await ScheduleService.GetScheduleById(ScheduleId);
            return ScheduleMapper.MapperToDTO(Schedule);
        }
    }
}