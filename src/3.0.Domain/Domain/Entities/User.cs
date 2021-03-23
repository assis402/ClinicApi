using System;
using System.Collections.Generic;
using Domain.Validators;
using Domain.Exceptions;
using Presentation.Utils.Messages;

namespace Domain.Entities
{
    public class User : Base
    {
        public string TaxNumber { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public ClinicalUnit ClinicalUnit { get; set; }

        public int ClinicalUnitId { get; set; }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public User(string taxNumber, string password, string name, string email, string phoneNumber, int clinicalUnitId, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) 
        : base(creationDate, updateDate, deletionDate)
        {
            TaxNumber = taxNumber;
            Password = password;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            ClinicalUnitId = clinicalUnitId;
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