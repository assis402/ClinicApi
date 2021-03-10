using System;
using Infrastructure.Repository.Repositories;
using Domain.Core.Interfaces.Repositories;
using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ClinicContext context = null;
        private Repository<ClinicUnit> clinicUnitRepository = null;
        private Repository<User> userRepository = null;
        private Repository<Schedule> scheduleRepository = null;

        public UnitOfWork()
        {
            context = new ClinicContext();
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public IRepository<ClinicUnit> ClinicUnitRepository
        {
            get
            {
                if (clinicUnitRepository == null)
                {
                    clinicUnitRepository = new Repository<ClinicUnit>(context);
                }
                return clinicUnitRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new Repository<User>(context);
                }
                return userRepository;
            }
        }

        public IRepository<Schedule> ScheduleRepository
        {
            get
            {
                if (scheduleRepository == null)
                {
                    scheduleRepository = new Repository<Schedule>(context);
                }
                return scheduleRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
