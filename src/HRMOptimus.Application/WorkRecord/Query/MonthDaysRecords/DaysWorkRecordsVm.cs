using System;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords
{
    public record DaysWorkRecordsVm(TimeSpan StartHour, TimeSpan EndHour, DateTime Day, TimeSpan WorkedTime, TimeSpan WorkedTimeFromAllDays);
}