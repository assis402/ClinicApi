using System.Collections.Generic;

namespace ClinicApi.Domain.Entities
{
    public class ClinicUnit : Base
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public ICollection<User> Users { get; set; }
    }
}