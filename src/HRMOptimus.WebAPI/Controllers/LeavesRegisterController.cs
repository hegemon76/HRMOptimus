using HRMOptimus.Application.LeaveRegister.Command.AddLeaveRegister;
using HRMOptimus.Application.LeaveRegister.Command.ChangeStatusLeaveRegister;
using HRMOptimus.Application.LeaveRegister.Command.DeleteLeaveRegister;
using HRMOptimus.Application.LeaveRegister.Query.GetLeavesRegisterByEmployeeId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [Route("/api/leavesRegister")]
    [Authorize]
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
        public async Task<ActionResult> DeleteById(int id, int employeeId)
        {
            await Mediator.Send(new DeleteLeaveRegisterCommand() { Id = id, EmployeeId = employeeId });

            return NoContent();
        }

        [HttpPut]
        [Route("changeStatus")]
        public async Task<ActionResult> ChangeStatusById(ChangeStatusLeaveRegisterVm changeStatus)
        {
            await Mediator.Send(new ChangeStatusLeaveRegisterCommand() { ChangeStatusLeaveRegisterVm = changeStatus });

            return NoContent();
        }
    }
}