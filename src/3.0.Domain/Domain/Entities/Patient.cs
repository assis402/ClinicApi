using System;
using System.Collections.Generic;
using Domain.Validators;
using Domain.Exceptions;
using Domain.Enums;
using Presentation.Utils.Messages;

namespace Domain.Entities
{
    public class Patient : User
    {
        public ICollection<Schedule> Schedules { get; private set; }

        public Patient(string taxNumber, string password, string name, string email, string phoneNumber, int clinicalUnitId, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) 
        : base(taxNumber, password, name, email, phoneNumber, UserRole.Common, clinicalUnitId, creationDate, updateDate, deletionDate)
        {
        }

        public override bool Validate()
        {
            List<string> Errors = new List<string>();

            var baseValidator = new BaseValidator();
            var baseValidation = baseValidator.Validate(this);
            var entityValidator = new UserValidator();
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