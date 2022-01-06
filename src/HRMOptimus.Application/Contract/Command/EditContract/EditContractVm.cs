using HRMOptimus.Domain.Enums;

namespace HRMOptimus.Application.Contract.Command.EditContract
{
    public class EditContractVm
    {
        public int ContractId { get; set; }
        public string ContractName { get; set; }
        public decimal? LeaveDays { get; set; }
        public decimal? Payment { get; set; }
        public decimal? Rate { get; set; }
        public int? WorkTime { get; set; }
        public ContractType ContractType { get; set; }
    }
}