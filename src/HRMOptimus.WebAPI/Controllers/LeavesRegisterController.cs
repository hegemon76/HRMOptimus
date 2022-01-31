using HRMOptimus.Application.LeaveRegister.Command.AddLeaveRegister;
using HRMOptimus.Application.LeaveRegister.Command.ChangeStatusLeaveRegister;
using HRMOptimus.Application.LeaveRegister.Command.DeleteLeaveRegister;
using HRMOptimus.Application.LeaveRegister.Query.GetLeavesRegisterByEmployeeId;
using HRMOptimus.Domain.Enums;
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
        public async Task<ActionResult<int>> AddLeaveRegister(AddLeaveRegisterVm model)
        {
            return await Mediator.Send(new AddLeaveRegisterCommand() { AddLeaveRegisterVm = model });
        }

        [HttpGet]
        [Route("getByEmployeeId")]
        public async Task<LeavesRegisterVm> GetEmployeeWithLeavesRegister(int employeeId)
        {
            return await Mediator.Send(new GetLeavesRegisterByEmployeeIdQuery() { EmployeeId = employeeId });
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator, HumanResources")]
        [Route("delete")]
        public async Task<ActionResult> DeleteLeaveRegisterById(int id, int employeeId)
        {
            await Mediator.Send(new DeleteLeaveRegisterCommand() { Id = id, EmployeeId = employeeId });

            return NoContent();
        }

        [HttpPut]
        [Authorize(Roles = "Administrator, HumanResources")]
        [Route("changeStatus")]
        public async Task<ActionResult> ChangeStatusLeaveRegisterById(ChangeStatusLeaveRegisterVm changeStatus)
        {
            await Mediator.Send(new ChangeStatusLeaveRegisterCommand() { ChangeStatusLeaveRegisterVm = changeStatus });

            return NoContent();
        }
    }
}