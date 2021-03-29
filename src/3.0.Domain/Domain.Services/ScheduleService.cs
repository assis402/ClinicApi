using System;
using Domain.Core.Interfaces.Services;
using Domain.Core.Interfaces.Repositories;
using Infrastructure.Repository;
using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ScheduleService : IScheduleService
    {
        public async Task<Schedule> GetScheduleById(int ScheduleId)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                return await uow.ScheduleRepository.GetByIdAsync(ScheduleId);                                                                                                                                                
            }
        }

        public async Task<Schedule> InsertSchedule(Schedule Schedule)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                Schedule entity = await uow.ScheduleRepository.AddAsync(Schedule);
                await uow.Commit();
                return entity;                                                                                                                                                        
            }
        }
    }
}
