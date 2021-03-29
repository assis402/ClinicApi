using System;

namespace Application.DTO
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        
        public DateTime ScheduleDate { get; set; }

        public int PatientId { get; set; }

        public int ClinicalUnitId { get; set; }
    }
}