using System;
using Domain.Core.Interfaces.Services;
using Domain.Core.Interfaces.Repositories;
using Infrastructure.Repository;
using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ClinicalUnitService : IClinicalUnitService
    {
        public async Task<ClinicalUnit> GetClinicalUnitById(int ClinicalUnitId)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                return await uow.ClinicalUnitRepository.GetByIdAsync(ClinicalUnitId);                                                                                                                                                
            }
        }

        public async Task<string> InsertClinicalUnit(ClinicalUnit ClinicalUnit)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                await uow.ClinicalUnitRepository.AddAsync(ClinicalUnit);
                await uow.Commit(); 
                return "Ok";                                                                                                                                                                
            }
        }
    }
}
