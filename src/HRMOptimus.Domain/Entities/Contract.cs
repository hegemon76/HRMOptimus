using HRMOptimus.Domain.Common;
using HRMOptimus.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMOptimus.Domain.Entities
{
    public class Contract: EntityBase
    {
        public int Id { get; set; }
        public string ContractName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LeaveDays { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Payment { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }
        public int WorkTime { get; set; }
        public Employee Employee { get; set; }
        public ContractType ContractType { get; set; }
    }
}
