using HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public record DayWorkRecordsVm(List<Domain.Entities.WorkRecord> WorkRecords, DateTime DayWork);
}