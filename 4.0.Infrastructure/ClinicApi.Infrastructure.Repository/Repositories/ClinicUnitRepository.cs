using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Core.Interfaces.Repositories;

namespace ClinicApi.Infrastructure.Repository.Repositories
{
    public class ClinicUnitRepository : BaseRepository<ClinicUnit>, IClinicUnitRepository
    {
        public ClinicUnitRepository(dbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}