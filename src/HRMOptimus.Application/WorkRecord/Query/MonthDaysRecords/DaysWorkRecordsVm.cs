using HRMOptimus.Application.WorkRecord.Query.DayWorkRecords;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords
{
    public record DaysWorkRecordsVm(TimeSpan StartHour, TimeSpan EndHour, DateTime Day, TimeSpan WorkedTime);
}