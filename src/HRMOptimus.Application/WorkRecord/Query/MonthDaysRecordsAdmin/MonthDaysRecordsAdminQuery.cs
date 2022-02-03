using HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords;
using MediatR;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecordsAdmin
{
    public class MonthDaysRecordsAdminQuery : IRequest<MonthWorkRecordsVm>
    {
        public int? MonthFromCurrent { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int EmployeeId { get; set; }
    }
}