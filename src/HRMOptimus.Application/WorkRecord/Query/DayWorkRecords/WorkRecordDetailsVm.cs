using System;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public record WorkRecordDetailsVm(int Id, string Name, DateTime WorkStart, DateTime WorkStop, TimeSpan Duration,
        string ProjectName);
}