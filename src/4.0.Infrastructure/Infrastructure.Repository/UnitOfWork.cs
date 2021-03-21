using System;
using Domain.Core.Interfaces.Repositories;
using Infrastructure.Data;
using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ClinicAppContext context = null;
        private Repository<ClinicalUnit> clinicalUnitRepository = null;
        private Repository<User> userRepository = null;
        private Repository<Schedule> scheduleRepository = null;

        public UnitOfWork()
        {
            context = new ClinicAppContext();
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public IRepository<ClinicalUnit> ClinicalUnitRepository
        {
            get
            {
                if (ClinicalUnitRepository == null)
                {
                    clinicalUnitRepository = new Repository<ClinicalUnit>(context);
                }
                return ClinicalUnitRepository;
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
