using MediatR;
using System;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords
{
    public class MonthDaysRecordsQuery : IRequest<MonthDaysRecordsVm>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}