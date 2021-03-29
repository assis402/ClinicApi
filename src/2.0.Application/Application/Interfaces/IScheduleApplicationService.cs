using Application.DTO;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IScheduleApplicationService
    {
         Task<ScheduleDTO> InsertSchedule(ScheduleDTO ScheduleDTO);

         Task<ScheduleDTO> GetScheduleById(int ScheduleId);
    }
}