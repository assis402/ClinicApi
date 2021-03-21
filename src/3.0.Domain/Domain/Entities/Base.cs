using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime UpdateDate { get; private set; }

        public DateTime? DeletionDate { get; private set; }

        internal List<string> _errors;

        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();

        public Base(DateTime creationDate, DateTime updateDate, DateTime? deletionDate)
        {
            CreationDate = creationDate;
            UpdateDate = updateDate;
            DeletionDate = deletionDate;
        }

        //public void Delete()
    }
}