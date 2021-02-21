using System.Threading.Tasks;
using ClinicApi.Domain.Entities;

namespace ClinicApi.Domain.Core.Interfaces.Services
{
    public interface IScheduleService
    {
        Task<string> InsertSchedule(Schedule schedule);

        Task<ClinicUnit> GetScheduleByUserId(int id);

        Task<ClinicUnit> GetScheduleByClinicUnitId(int id);

        Task<string> Reschedule(Schedule schedule);

        Task<string> UndoShedule(Schedule schedule);
    }
}