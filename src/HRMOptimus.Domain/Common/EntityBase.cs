using System;

namespace HRMOptimus.Domain.Common
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string InactivatedBy { get; set; }
        public DateTime? InactivatedOn { get; set; }
        public bool Enabled { get; set; }
    }
}