using System.Collections.Generic;

namespace Domain.Entities
{
    public class ClinicUnit : Base
    {
        public string CompanyName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public ICollection<User> Users { get; set; }
    }
}