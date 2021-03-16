using System.Collections.Generic;
using System;

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
        } 
    }
}