using HRMOptimus.Application.WorkRecord.Command.AddWorkRecord;
using HRMOptimus.Application.WorkRecord.Query.DayWorkRecords;
using HRMOptimus.Application.WorkRecord.Query.WorkRecordDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    public class WorkRecordController : BaseController
    {
        [HttpPost]
        [Route("api/workRecord/add")]
        public async Task<ActionResult<int>> AddNewWorkRecord ([FromBody] WorkRecordVm model)
        {
            var id = await Mediator.Send(new AddWorkRecordCommand() { WorkRecordVm = model });

            return id;
        }

        [HttpGet]
        [Route("api/workRecord/")]
        public async Task<ActionResult<WorkRecordDetailsVm>> WorkRecordDetails(int workRecordId)
        {
            var workRecord = await Mediator.Send(new WorkRecordDetailsQuery() { WorkRecordId = workRecordId });

            return workRecord;
        }

        [HttpGet]
        [Route("api/workRecords/")]
        public async Task<ActionResult<DayWorkRecordsVm>> WorkDayRecords(DateTime dayWork)
        {
            var workRecords = await Mediator.Send(new DayWorkRecordsQuery() { DayWork = dayWork });

            return workRecords;
        }

        //[HttpGet]
        //[Route("api/dayWorkRecords/")]
        //public async Task<ActionResult<DayWorkRecordsVm>> WorkMonthDays(DateTime day)
        //{
        //    var workRecords = await Mediator.Send(new DayWorkRecordsQuery() { DayWork = day });

        //    return workRecords;
        //}
    }
}
