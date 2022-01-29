using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords
{
    public record MonthWorkRecordsVm(string WorkFromAllDays, List<DaysWorkRecordsVm> DaysWorkRecords);
}