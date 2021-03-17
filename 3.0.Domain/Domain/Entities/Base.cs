using System;

namespace Domain.Entities
{
    public class Base
    {
        public int Id { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime UpdateDate { get; private set; }

        public DateTime? DeletionDate { get; private set; }

        public Base(DateTime createDate, DateTime updateDate, DateTime? deletionDate)
        {
            CreationDate = createDate;
            UpdateDate = updateDate;
            DeletionDate = deletionDate;
        }

        //public void Delete()
    }
}