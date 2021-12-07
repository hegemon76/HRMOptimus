using HRMOptimus.Application.WorkRecord.Query.DayWorkRecords;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords
{
    public record DaysWorkRecordsVm(List<WorkRecordVm> WorkRecords, DateTime Day, TimeSpan WorkedTime);
}