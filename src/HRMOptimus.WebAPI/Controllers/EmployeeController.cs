using HRMOptimus.Application.Common.Models;
using HRMOptimus.Application.Contract.Command.EditContract;
using HRMOptimus.Application.Employee.Command.EditEmployee;
using HRMOptimus.Application.Employee.Command.RemoveEmployee;
using HRMOptimus.Application.Employee.Query.AdminEmployees;
using HRMOptimus.Application.Employee.Query.EmployeeDetails;
using HRMOptimus.Application.Employee.Query.Employees;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [Route("/api")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        [HttpGet]
        [Route("employees")]
        public async Task<ActionResult<PageResult<EmployeeVm>>> GetEmployees([FromQuery] SearchQuery searchQuery)
        {
            var employees = await Mediator.Send(new EmployeesQuery() { Query = searchQuery });

            return employees;
        }

        [HttpGet]
        [Route("adminEmployees")]
        public async Task<ActionResult<List<AdminEmployeesVm>>> GetAdminEmployees()
        {
            var employees = await Mediator.Send(new GetAllAdminEmployeesQuery() { });

            return employees;
        }

        [HttpGet]
        [Route("employee/details/")]
        public async Task<ActionResult<EmployeeDetailsVm>> GetEmployee(int? employeeId, string name)
        {
            var employee = await Mediator.Send(new EmployeeDetailsQuery() { EmployeeId = employeeId, Name = name });

            return employee;
        }

        [HttpDelete]
        [Route("employee/delete/")]
        public async Task<ActionResult> RemoveEmployee(int employeeId)
        {
            await Mediator.Send(new RemoveEmployeeCommand() { EmployeeId = employeeId });

            return NoContent();
        }

        [HttpPut]
        [Route("editEmployee")]
        public async Task<IActionResult> EditEmployee([FromBody] EditEmployeeVm model)
        {
            await Mediator.Send(new EditEmployeeCommand() { Employee = model });

            return Ok();
        }

        [HttpPut]
        [Route("editContract")]
        public async Task<IActionResult> EditContract([FromBody] EditContractVm model)
        {
            await Mediator.Send(new EditContractCommand() { EditContractVm = model });

            return Ok();
        }
    }
}