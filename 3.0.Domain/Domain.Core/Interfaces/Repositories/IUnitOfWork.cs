using System;
using Domain.Entities;
using Domain.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ClinicUnit> ClinicUnitRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Schedule> ScheduleRepository { get; }
        Task Commit();
    }
}
