using System;
using Domain.Core.Interfaces.Services;
using Domain.Core.Interfaces.Repositories;
using Infrastructure.Repository;
using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ClinicUnitService : IClinicUnitService
    {
        public async Task<ClinicUnit> GetClinicUnitById(int clinicUnitId)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                return await uow.ClinicUnitRepository.GetByIdAsync(clinicUnitId);                                                                                                                                                
            }
        }

        public async Task<string> InsertClinicUnit(ClinicUnit clinicUnit)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                await uow.ClinicUnitRepository.AddAsync(clinicUnit);
                await uow.Commit(); 
                return "Ok";                                                                                                                                                                
            }
        }
    }
}
