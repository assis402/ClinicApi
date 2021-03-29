using System;
using System.Collections.Generic;
using Domain.Validators;
using Domain.Exceptions;
using Domain.Enums;
using Presentation.Utils.Messages;

namespace Domain.Entities
{
    public class CompanyProfile : User
    {
        public CompanyProfile(string taxNumber, string password, string name, string email, string phoneNumber, UserRole role, int clinicalUnitId, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) 
        : base(taxNumber, password, name, email, phoneNumber, role, clinicalUnitId, creationDate, updateDate, deletionDate)
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