using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core.Interfaces.Services
{
    public interface IScheduleService
    {
        Task<string> InsertSchedule(Schedule schedule);

        Task<ClinicalUnit> GetScheduleByUserId(int scheduleId);

        Task<ClinicalUnit> GetAllSchedulesByClinicalUnitId(int ClinicalUnitId);

        Task<string> Reschedule(Schedule schedule);

        Task<string> UndoShedule(Schedule schedule);
    }
}