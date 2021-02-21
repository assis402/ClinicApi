using System.Collections.Generic;

namespace ClinicApi.Domain.Entities
{
    public class User : Base
    {
        public string CPF { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public ClinicUnit ClinicUnit { get; set; }

        public int ClinicUnitId { get; set; }
    }
}