﻿using HRMOptimus.Domain.Common;
using HRMOptimus.Domain.Enums;

namespace HRMOptimus.Domain.Entities
{
    public class Contract : EntityBase
    {
        public string ContractName { get; set; }
        public decimal LeaveDays { get; set; }
        public decimal Payment { get; set; }
        public decimal Rate { get; set; }
        public int WorkTime { get; set; }
        public ContractType ContractType { get; set; }
    }
}