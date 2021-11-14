using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMOptimus.Application.LeaveRegister.Command.AddLeaveRegister;
using HRMOptimus.Application.LeaveRegister.Query.GetLeavesRegisterByEmployeeId;

namespace HRMOptimus.WebAPI.Controllers
{
    public class LeavesRegisterController : BaseController
    {
        [HttpPost]
        [Route("api/leavesRegister/add")]
        public async Task<ActionResult<int>> Register(AddLeaveRegisterVm model)
        {
            var id = await Mediator.Send(new AddLeaveRegisterCommand() { AddLeaveRegisterVm = model });

            return id;
        }

        [HttpGet]
        [Route("api/leavesRegister/getByEmployeeId")]
        public async Task<List<LeavesRegisterListVm>> GetByEmployeeId(int employeeId)
        {
            List<LeavesRegisterListVm> leavesRegister = await Mediator.Send(new GetLeavesRegisterByEmployeeIdQuery() { EmployeeId = employeeId });

            return leavesRegister;
        }
    }
}
