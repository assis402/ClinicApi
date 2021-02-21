using System;

namespace ClinicApi.Domain.Entities
{
    public class Schedule : Base
    {
        public DateTime ScheduleDate { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}