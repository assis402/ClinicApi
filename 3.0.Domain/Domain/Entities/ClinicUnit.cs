using System.Collections.Generic;
using System;

namespace Domain.Entities
{
    public class ClinicUnit : Base
    {
        public string CompanyName { get; private set; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public ICollection<User> Users { get; private set; }

        public ClinicUnit(string companyName, string login, string password, DateTime createDate, DateTime updateTime, DateTime? deletionDate) 
        : base(createDate, updateTime, deletionDate)
        {
            CompanyName = companyName;
            Login = login;
            Password = password;
        }  
    }
}