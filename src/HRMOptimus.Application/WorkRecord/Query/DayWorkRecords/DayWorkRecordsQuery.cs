using MediatR;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public class DayWorkRecordsQuery : IRequest<List<WorkRecordDetailsVm>>
    {
        public DateTime DayWork { get; set; }
    }
}