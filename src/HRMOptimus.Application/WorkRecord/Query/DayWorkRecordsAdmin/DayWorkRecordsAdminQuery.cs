using HRMOptimus.Application.WorkRecord.Query.DayWorkRecords;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRMOptimus.Application.WorkRecord.Query.DayWorkRecordsAdmin
{
    public class DayWorkRecordsAdminQuery : IRequest<List<WorkRecordDetailsVm>>
    {
        public DateTime DayWork { get; set; }
        public int EmployeeId { get; set; }
    }
}