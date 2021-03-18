using System.Collections.Generic;
using System;
using Domain.Validators;

namespace Domain.Entities
{
    public class User : Base
    {
        public string Cpf { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public ClinicUnit ClinicUnit { get; set; }

        public int ClinicUnitId { get; set; }

        public User(string cpf, string password, string name, string email, string phoneNumber, int clinicUnitId, DateTime creationDate, DateTime updateDate, DateTime? deletionDate) 
        : base(creationDate, updateDate, deletionDate)
        {
            Cpf = cpf;
            Password = password;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            ClinicUnitId = clinicUnitId;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validade();
        }

        public override bool Validade()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new Exception("Os seguintes campos estão inválidos:", _errors);
            }

            return true;
        }
    }
}