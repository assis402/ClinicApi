using System;
using System.Collections.Generic;
using Domain.Validators;
using Domain.Exceptions;
using Domain.Enums;
using Presentation.Utils.Messages;
using Presentation.Utils;

namespace Domain.Entities
{
    public class User : Base
    {
        public string TaxNumber { get; private set; }

        public string Password { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }

        public UserRole Role { get; private set; }

        public ClinicalUnit ClinicalUnit { get; private set; }

        public int ClinicalUnitId { get; private set; }

        public ICollection<Protocol> Protocols { get; private set; }

        public User(string taxNumber, string password, string name, string email, string phoneNumber, UserRole role, int clinicalUnitId, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) : base(creationDate, updateDate, deletionDate)
        {
            TaxNumber = taxNumber;
            Password = CryptographyMD5.StringToMD5(password);
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
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