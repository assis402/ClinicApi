using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core.Interfaces.Services
{
    public interface IScheduleService
    {
        Task<Schedule> InsertSchedule(Schedule schedule);

        Task<Schedule> GetScheduleById(int scheduleId);

        //Task<ClinicalUnit> GetAllSchedulesByClinicalUnitId(int ClinicalUnitId);
    }
}