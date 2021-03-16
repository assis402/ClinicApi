using System;

namespace Domain.Entities
{
    public class Schedule : Base
    {
        public DateTime ScheduleDate { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public Schedule(DateTime scheduleDate, int userId, DateTime createDate, DateTime updateTime, DateTime? deletionDate) 
        : base(createDate, updateTime, deletionDate)
        {
            ScheduleDate = scheduleDate;
            UserId = userId;
        }  
    }
}