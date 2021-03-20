using System;
using System.Collections.Generic;
using Domain.Validators;
using Domain.Exceptions;


namespace Domain.Entities
{
    public class ClinicUnit : Base
    {
        public string CompanyName { get; private set; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public ICollection<User> Users { get; private set; }

        public ICollection<Schedule> Schedules { get; private set; }

        public ClinicUnit(string companyName, string login, string password, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) 
        : base(creationDate, updateDate, deletionDate)
        {
            CompanyName = companyName;
            Login = login;
            Password = password;
            _errors = new List<string>();
        }  

        public override bool Validade()
        {
            var validator = new ClinicUnitValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Os seguintes campos estão inválidos:", _errors);
            }

            return true;
        }
    }
}