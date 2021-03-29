using System;
using System.Collections.Generic;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Validators;
using Presentation.Utils.Messages;

namespace Domain.Entities
{
    public class Specialty : Base
    {
        public string Title { get; private set; }

        public int ClinicalUnitId { get; private set; }

        public Specialty(string title, int clinicalUnitId, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) : base(creationDate, updateDate, deletionDate)
        {
            Title = title;
            ClinicalUnitId = clinicalUnitId;
        }

        public override bool Validate()
        {
            List<string> Errors = new List<string>();

            var baseValidator = new BaseValidator();
            var baseValidation = baseValidator.Validate(this);
            var entityValidator = new SpecialtyValidator();
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