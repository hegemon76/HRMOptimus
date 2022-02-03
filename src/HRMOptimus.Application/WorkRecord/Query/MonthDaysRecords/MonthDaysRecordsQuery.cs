using MediatR;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords
{
    public class MonthDaysRecordsQuery : IRequest<MonthWorkRecordsVm>
    {
        public int? MonthFromCurrent { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}