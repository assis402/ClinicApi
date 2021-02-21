using System;
using System.Globalization;

namespace ClinicApi.Domain.Entities
{
    public class Base
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime DeletionDate { get; set; }
    }
}