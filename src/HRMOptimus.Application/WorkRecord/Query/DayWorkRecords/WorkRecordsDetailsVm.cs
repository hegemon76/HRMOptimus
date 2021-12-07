using System;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public record WorkRecordsDetailsVm(int Id, string Name, DateTime WorkStart, DateTime WorkStop, TimeSpan Duration,
        string ProjectName);
}