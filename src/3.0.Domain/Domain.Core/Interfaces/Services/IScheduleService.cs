using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core.Interfaces.Services
{
    public interface IScheduleService
    {
        Task<string> InsertSchedule(Schedule schedule);

        Task<ClinicUnit> GetScheduleByUserId(int scheduleId);

        Task<ClinicUnit> GetAllSchedulesByClinicUnitId(int clinicUnitId);

        Task<string> Reschedule(Schedule schedule);

        Task<string> UndoShedule(Schedule schedule);
    }
}