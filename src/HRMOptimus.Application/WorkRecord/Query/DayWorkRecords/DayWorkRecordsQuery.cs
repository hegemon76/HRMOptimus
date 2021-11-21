using MediatR;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public class DayWorkRecordsQuery : IRequest<List<WorkRecordVm>>
    {
        public DateTime DayWork { get; set; }
    }
}