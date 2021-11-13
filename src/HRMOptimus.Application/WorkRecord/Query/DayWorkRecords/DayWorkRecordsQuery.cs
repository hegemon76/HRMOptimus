using MediatR;
using System;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecords
{
    public class DayWorkRecordsQuery : IRequest<DayWorkRecordsVm>
    {
        public DateTime DayWork { get; set; }
    }
}
