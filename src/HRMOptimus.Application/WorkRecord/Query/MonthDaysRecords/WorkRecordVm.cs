using System;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords
{
    public record WorkRecordVm(int Id, DateTime WorkStart, DateTime WorkStop, TimeSpan Duration);
}