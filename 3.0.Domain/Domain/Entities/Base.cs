using System;

namespace Domain.Entities
{
    public class Base
    {
        public int Id { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime UpdateDate { get; private set; }

        public DateTime? DeletionDate { get; private set; }

        public Base(DateTime createDate, DateTime updateTime, DateTime? deletionDate)
        {
            CreationDate = createDate;
            UpdateDate = updateTime;
            DeletionDate = deletionDate;
        }
    }
}