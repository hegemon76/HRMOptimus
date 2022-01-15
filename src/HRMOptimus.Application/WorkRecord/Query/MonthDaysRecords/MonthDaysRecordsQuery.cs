using MediatR;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords
{
    public class MonthDaysRecordsQuery : IRequest<List<DaysWorkRecordsVm>>
    {
        public int? MonthFromCurrent { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int? EmployeeId { get; set; }
    }
}