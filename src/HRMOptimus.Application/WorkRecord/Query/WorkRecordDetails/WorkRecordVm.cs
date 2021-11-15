using System;

namespace HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails
{
    public record WorkRecordVm(string Name, DateTime WorkStart, DateTime WorkStop, TimeSpan Duration);
}