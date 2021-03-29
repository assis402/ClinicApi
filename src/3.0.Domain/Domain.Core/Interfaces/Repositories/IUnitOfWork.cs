using System;
using Domain.Entities;
using Domain.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ClinicalUnit> ClinicalUnitRepository { get; }
        IRepository<Patient> PatientRepository { get; }
        IRepository<CompanyProfile> CompanyProfileRepository { get; }
        IRepository<Schedule> ScheduleRepository { get; }
        Task Commit();
    }
}
