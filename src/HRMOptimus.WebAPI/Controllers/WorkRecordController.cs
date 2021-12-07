using HRMOptimus.Application.WorkRecord.Command.AddWorkRecord;
using HRMOptimus.Application.WorkRecord.Command.RemoveWorkRecord;
using HRMOptimus.Application.WorkRecord.Command.UpdateWorkRecord;
using HRMOptimus.Application.WorkRecord.Query.DayWorkRecords;
using HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords;
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
        public async Task<ActionResult<int>> AddWorkRecord([FromBody] AddWorkRecordVm model)
        {
            var id = await Mediator.Send(new AddWorkRecordCommand() { AddWorkRecordVm = model });

            return id;
        }

        [HttpPut]
        [Route("api/workrecord/update")]
        public async Task<ActionResult> UpdateWorkRecord([FromBody] UpdateWorkRecordVm model)
        {
            await Mediator.Send(new UpdateWorkRecordCommand() { UpdateWorkRecordVm = model });

            return Ok();
        }

        [HttpGet]
        [Route("api/workrecord/day/")]
        public async Task<ActionResult<List<WorkRecordsDetailsVm>>> WorkDayRecords(DateTime dayWork)
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