using System;
using System.Collections.Generic;
using Domain.Validators;
using Domain.Exceptions;
using Presentation.Utils.Messages;


namespace Domain.Entities
{
    public class ClinicalUnit : Base
    {
        public string CompanyName { get; private set; }

        public string TaxNumber { get; private set; }

        public ICollection<User> Users { get; private set; }

        public ICollection<Schedule> Schedules { get; private set; }

        public ClinicalUnit(string companyName, string taxNumber, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) 
        : base(creationDate, updateDate, deletionDate)
        {
            CompanyName = companyName;
            TaxNumber = taxNumber;
            _errors = new List<string>();
        }  

        public override bool Validate()
        {
            var baseValidator = new BaseValidator();
            var baseValidation = baseValidator.Validate(this);
            var entityValidator = new ClinicalUnitValidator();
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