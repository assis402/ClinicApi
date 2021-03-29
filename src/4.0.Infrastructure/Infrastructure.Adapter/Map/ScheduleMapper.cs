using System;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Adapter.Interfaces;
using System.Collections.Generic;
using Application.DTO;

namespace Infrastructure.Adapter.Map
{
    public class ScheduleMapper : IScheduleMapper
    {
        ICollection<ScheduleDTO> ScheduleDTOs { get; set; }

        public Schedule MapperToEntity(ScheduleDTO ScheduleDTO)
        {
            Schedule Schedule = new Schedule
            (
                ScheduleDTO.ScheduleDate,
                ScheduleDTO.PatientId,
                ScheduleDTO.ClinicalUnitId,
                DateTime.Now,
                DateTime.Now,
                null
            );

            return Schedule;
        }

        public ICollection<ScheduleDTO> MapperListSchedule(ICollection<Schedule> Schedules)
        {
            foreach (var item in Schedules)
            {
                ScheduleDTO ScheduleDTO = new ScheduleDTO
                {
                    ScheduleDate = item.ScheduleDate,
                    PatientId = item.PatientId,
                    ClinicalUnitId = item.ClinicalUnitId
                };

                ScheduleDTOs.Add(ScheduleDTO);
            }

            return ScheduleDTOs;
        }

        public ScheduleDTO MapperToDTO(Schedule Schedule)
        {
            ScheduleDTO ScheduleDTO = new ScheduleDTO
            {
                ScheduleDate = Schedule.ScheduleDate,
                PatientId = Schedule.PatientId,
                ClinicalUnitId = Schedule.ClinicalUnitId
            };

            return ScheduleDTO;
        }
    }
}
