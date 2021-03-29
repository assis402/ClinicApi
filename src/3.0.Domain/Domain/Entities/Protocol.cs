using System;
using System.Collections.Generic;
using Domain.Enums;
using Domain.Validators;
using Domain.Exceptions;
using Presentation.Utils.Messages;

namespace Domain.Entities
{
    public class Protocol : Base
    {
        public string ProtocolNumber { get; private set; }

        public ActionType ActionType { get; private set; }

        public ClinicalUnit ClinicalUnit { get; private set; }

        public int ClinicalUnitId { get; private set; }

        public User User { get; private set; }

        public int UserId { get; set; }

        public Protocol(ActionType actionType, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) 
        : base(creationDate, updateDate, deletionDate)
        {
            ProtocolNumber = GenerateProtocolNumber();
            ActionType = actionType;
        }

        public string GenerateProtocolNumber()
        {
            Random Rnd = new Random();
            string ProtocolNumber = 
                    UserId 
                    + ActionType.ToString("D2") 
                    + DateTime.Now.ToString("yyyy''MM''dd'fff")
                    + Rnd.Next(999).ToString("D3");
            return ProtocolNumber;
        }

        public override bool Validate()
        {
            List<string> Errors = new List<string>();

            var baseValidator = new BaseValidator();
            var baseValidation = baseValidator.Validate(this);
            var entityValidator = new ProtocolValidator();
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