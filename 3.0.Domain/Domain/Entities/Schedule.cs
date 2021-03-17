using System;

namespace Domain.Entities
{
    public class Schedule : Base
    {
        public DateTime ScheduleDate { get; private set; }

        public User User { get; private set; }

        public int UserId { get; private set; }

        public ClinicUnit ClinicUnit { get; set; }

        public int ClinicUnitId { get; private set; }

        public Schedule(DateTime scheduleDate, int userId, int clinicUnitId, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) 
        : base(creationDate, updateDate, deletionDate)
        {
            ScheduleDate = scheduleDate;
            UserId = userId;
            ClinicUnitId = clinicUnitId;
        }  
    }
}