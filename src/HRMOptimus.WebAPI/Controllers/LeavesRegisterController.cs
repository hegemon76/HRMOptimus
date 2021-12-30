using HRMOptimus.Application.LeaveRegister.Command.AddLeaveRegister;
using HRMOptimus.Application.LeaveRegister.Command.ChangeStatusLeaveRegister;
using HRMOptimus.Application.LeaveRegister.Command.DeleteLeaveRegister;
using HRMOptimus.Application.LeaveRegister.Query.GetLeavesRegisterByEmployeeId;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [Route("/api/leavesRegister")]
    [ApiController]
    public class LeavesRegisterController : BaseController
    {
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<int>> Register(AddLeaveRegisterVm model)
        {
            return await Mediator.Send(new AddLeaveRegisterCommand() { AddLeaveRegisterVm = model });
        }

        [HttpGet]
        [Route("getByEmployeeId")]
        public async Task<LeavesRegisterVm> GetByEmployeeId(int employeeId)
        {
            var token = this.HttpContext.Request.Headers.ContainsKey("HeaderAuthorization");
            return await Mediator.Send(new GetLeavesRegisterByEmployeeIdQuery() { EmployeeId = employeeId });
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<int> DeleteById([FromRoute]DeleteLeaveRegisterVm registerId)
        {
            return await Mediator.Send(new DeleteLeaveRegisterCommand() { DeleteLeaveRegisterVm = registerId });
        }

        [HttpPut]
        [Route("changeStatus")]
        public async Task<int> ChangeStatusById(ChangeStatusLeaveRegisterVm changeStatus)
        {
            return await Mediator.Send(new ChangeStatusLeaveRegisterCommand() { ChangeStatusLeaveRegisterVm = changeStatus });
        }
    }
}