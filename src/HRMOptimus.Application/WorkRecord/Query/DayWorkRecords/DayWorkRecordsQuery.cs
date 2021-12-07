using MediatR;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public class DayWorkRecordsQuery : IRequest<List<WorkRecordsDetailsVm>>
    {
        public DateTime DayWork { get; set; }
    }
}