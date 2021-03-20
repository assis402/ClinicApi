using System;
using System.Collections.Generic;
using Domain.Validators;
using Domain.Exceptions;

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
            _errors = new List<string>();
        }  

        public override bool Validade()
        {
            var validator = new ScheduleValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Os seguintes campos estão inválidos:", _errors);
            }

            return true;
        }
    }
}