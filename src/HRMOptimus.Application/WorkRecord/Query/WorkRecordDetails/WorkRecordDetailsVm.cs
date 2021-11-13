using System;

namespace HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails
{
    public record WorkRecordDetailsVm(string Name, DateTime WorkStart, DateTime WorkStop, TimeSpan Duration,
        string ProjectName, string EmployeeName);
}
