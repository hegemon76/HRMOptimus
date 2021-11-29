using HRMOptimus.Application.WorkRecord.Command.AddWorkRecord;
using HRMOptimus.Application.WorkRecord.Command.RemoveWorkRecord;
using HRMOptimus.Application.WorkRecord.Query.DayWorkRecords;
using HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords;
using HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [ApiController]
    public class WorkRecordController : BaseController
    {
        [HttpPost]
        [Route("api/workrecord/add")]
        public async Task<ActionResult<int>> AddNewWorkRecord([FromBody] AddWorkRecordVm model)
        {
            var id = await Mediator.Send(new AddWorkRecordCommand() { AddWorkRecordVm = model });

            return id;
        }

        [HttpGet]
        [Route("api/workrecord/details/")]
        public async Task<ActionResult<WorkRecordDetailsVm>> WorkRecordDetails(int workRecordId)
        {
            var workRecord = await Mediator.Send(new WorkRecordDetailsQuery() { WorkRecordId = workRecordId });

            return workRecord;
        }

        [HttpGet]
        [Route("api/workrecord/day/")]
        public async Task<ActionResult<List<WorkRecordVm>>> WorkDayRecords(DateTime dayWork)
        {
            var dayWorkRecords = await Mediator.Send(new DayWorkRecordsQuery() { DayWork = dayWork });

            return dayWorkRecords;
        }

        [HttpGet]
        [Route("api/workrecord/month/")]
        public async Task<ActionResult<List<DaysWorkRecordsVm>>> MonthDaysRecords(DateTime dateFrom, DateTime dateTo)
        {
            var daysWorkRecords = await Mediator.Send(new MonthDaysRecordsQuery() { DateFrom = dateFrom, DateTo = dateTo });

            return daysWorkRecords;
        }

        [HttpDelete]
        [Route("api/workrecord/delete/")]
        public async Task<ActionResult> RemoveWorkRecord(int workRecordId)
        {
            await Mediator.Send(new RemoveWorkRecordCommand() { WorkRecordId = workRecordId });

            return NoContent();
        }
    }
}