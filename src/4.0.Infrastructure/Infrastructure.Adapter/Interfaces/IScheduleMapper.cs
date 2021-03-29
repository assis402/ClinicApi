using System;
using Domain.Entities;
using System.Collections.Generic;
using Application.DTO;

namespace Infrastructure.Adapter.Interfaces
{
    public interface IScheduleMapper
    {
        Schedule MapperToEntity(ScheduleDTO ScheduleDTO);

        ICollection<ScheduleDTO> MapperListSchedule(ICollection<Schedule> Schedules);

        ScheduleDTO MapperToDTO(Schedule Schedule);
    }
}