using HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords
{
    public record MonthDaysRecordsVm(List<WorkRecordVm> WorkRecords, int Month);
}