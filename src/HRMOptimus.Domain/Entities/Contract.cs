using HRMOptimus.Domain.Common;
using HRMOptimus.Domain.Enums;

namespace HRMOptimus.Domain.Entities
{
    public class Contract: EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal WorkTime { get; set; } // part time - full time
        public ContractType ContractType { get; set; }
    }
}
