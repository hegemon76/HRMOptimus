using System;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public record WorkRecordVm(string Name, DateTime WorkStart, DateTime WorkStop, TimeSpan Duration);
}