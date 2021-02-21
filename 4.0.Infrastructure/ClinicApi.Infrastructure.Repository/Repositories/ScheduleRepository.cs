using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Core.Interfaces.Repositories;

namespace ClinicApi.Infrastructure.Repository.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(dbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}