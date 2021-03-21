using System;
using System.Collections.Generic;
using Domain.Validators;
using Domain.Exceptions;
using Presentation.Utils.Messages;

namespace Domain.Entities
{
    public class Schedule : Base
    {
        public DateTime ScheduleDate { get; private set; }

        public User User { get; private set; }

        public int UserId { get; private set; }

        public ClinicalUnit ClinicalUnit { get; set; }

        public int ClinicalUnitId { get; private set; }

        public Schedule(DateTime scheduleDate, int userId, int clinicalUnitId, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) 
        : base(creationDate, updateDate, deletionDate)
        {
            ScheduleDate = scheduleDate;
            UserId = userId;
            ClinicalUnitId = clinicalUnitId;
            _errors = new List<string>();
        }  

        public override bool Validate()
        {
            var baseValidator = new BaseValidator();
            var baseValidation = baseValidator.Validate(this);
            var entityValidator = new ScheduleValidator();
            var entityValidation = entityValidator.Validate(this);

            if(!baseValidation.IsValid || !entityValidation.IsValid)
            {
                foreach(var error in baseValidation.Errors)
                    _errors.Add(error.ErrorMessage);

                foreach(var error in entityValidation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException(ExceptionMessages.EXC014(), _errors);
            }

            return true;
        }
    }
}