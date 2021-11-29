using System;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public record WorkRecordVm(int Id, string Name, DateTime WorkStart, DateTime WorkStop, TimeSpan Duration);
}