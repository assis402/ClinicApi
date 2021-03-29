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

        public Patient Patient { get; private set; }

        public int PatientId { get; private set; }

        public ClinicalUnit ClinicalUnit { get; private set; }

        public int ClinicalUnitId { get; private set; }

        public Schedule(DateTime scheduleDate, int patientId, int clinicalUnitId, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) 
        : base(creationDate, updateDate, deletionDate)
        {
            ScheduleDate = scheduleDate;
            PatientId = patientId;
            ClinicalUnitId = clinicalUnitId;
        }  

        public override bool Validate()
        {
            List<string> Errors = new List<string>();

            var baseValidator = new BaseValidator();
            var baseValidation = baseValidator.Validate(this);
            var entityValidator = new ScheduleValidator();
            var entityValidation = entityValidator.Validate(this);

            if(!baseValidation.IsValid || !entityValidation.IsValid)
            {
                foreach(var error in baseValidation.Errors)
                    Errors.Add(error.ErrorMessage);

                foreach(var error in entityValidation.Errors)
                    Errors.Add(error.ErrorMessage);

                throw new DomainException(ExceptionMessages.EXC014(), Errors);
            }

            return true;
        }
    }
}