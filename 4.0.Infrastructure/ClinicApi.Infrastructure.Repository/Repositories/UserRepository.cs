using ClinicApi.Domain.Core.Interfaces.Repositories;
using ClinicApi.Domain.Entities;

namespace ClinicApi.Infrastructure.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(dbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }   
    }
}