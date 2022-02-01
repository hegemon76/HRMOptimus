using HRMOptimus.Application.WorkRecord.Command.AddWorkRecord;
using HRMOptimus.Application.WorkRecord.Command.RemoveWorkRecord;
using HRMOptimus.Application.WorkRecord.Command.UpdateWorkRecord;
using HRMOptimus.Application.WorkRecord.Query.DayWorkRecords;
using HRMOptimus.Application.WorkRecord.Query.MonthDaysRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/workrecord/")]
    public class WorkRecordController : BaseController
    {
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<int>> AddWorkRecord([FromBody] AddWorkRecordVm model)
        {
            var id = await Mediator.Send(new AddWorkRecordCommand() { AddWorkRecordVm = model });

            return id;
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateWorkRecord([FromBody] UpdateWorkRecordVm model)
        {
            await Mediator.Send(new UpdateWorkRecordCommand() { UpdateWorkRecordVm = model });

            return Ok();
        }

        [HttpGet]
        [Route("day")]
        public async Task<ActionResult<List<WorkRecordDetailsVm>>> WorkDayRecords(DateTime dayWork, int? employeeId)
        {
            var dayWorkRecords = await Mediator.Send(new DayWorkRecordsQuery() { DayWork = dayWork, EmployeeId = employeeId });

            return dayWorkRecords;
        }

        [HttpGet]
        [Route("month")]
        public async Task<ActionResult<MonthWorkRecordsVm>> MonthDaysRecords(int monthFromCurrent, int month, int year, int employeeId)
        {
            var daysWorkRecords = await Mediator.Send(new MonthDaysRecordsQuery()
            { MonthFromCurrent = monthFromCurrent, Month = month, Year = year, EmployeeId = employeeId });

            return daysWorkRecords;
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> RemoveWorkRecord(int workRecordId)
        {
            await Mediator.Send(new RemoveWorkRecordCommand() { WorkRecordId = workRecordId });

            return NoContent();
        }
    }
}