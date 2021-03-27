using System;
using System.Collections.Generic;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Validators;
using Presentation.Utils.Messages;

namespace Domain.Entities
{
    public class Specialist : User
    {
        
        public Formation Formation { get; set; }

        public string Specialty { get; set; }

        public Specialist(Formation formation, string specialty, string taxNumber, string password, string name, string email, string phoneNumber, int clinicalUnitId, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) : base(taxNumber, password, name, email, phoneNumber, clinicalUnitId, creationDate, updateDate, deletionDate)
        {
            Formation = formation;
            Specialty = specialty;
        }


        public override bool Validate()
        {
            List<string> Errors = new List<string>();

            var baseValidator = new BaseValidator();
            var baseValidation = baseValidator.Validate(this);
            var entityValidator = new SpecialistValidator();
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