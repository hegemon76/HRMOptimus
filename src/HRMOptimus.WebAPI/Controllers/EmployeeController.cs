﻿using HRMOptimus.Application.Common.Models;
using HRMOptimus.Application.Employee.Command.EditEmployee;
using HRMOptimus.Application.Employee.Command.RemoveEmployee;
using HRMOptimus.Application.Employee.Query.EmployeeDetails;
using HRMOptimus.Application.Employee.Query.Employees;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRMOptimus.WebAPI.Controllers
{
    [ApiController]
    public class EmployeeController : BaseController
    {
        [HttpGet]
        [Route("api/employees")]
        public async Task<ActionResult<PageResult<EmployeeVm>>> GetEmployees([FromQuery] SearchQuery searchQuery)
        {
            var employees = await Mediator.Send(new EmployeesQuery() { Query = searchQuery });

            return employees;
        }

        [HttpGet]
        [Route("api/employee/details/")]
        public async Task<ActionResult<EmployeeDetailsVm>> GetEmployee(int? employeeId, string name)
        {
            var employee = await Mediator.Send(new EmployeeDetailsQuery() { EmployeeId = employeeId, Name = name });

            return employee;
        }

        [HttpDelete]
        [Route("api/employee/delete/")]
        public async Task<ActionResult> RemoveEmployee(int employeeId)
        {
            await Mediator.Send(new RemoveEmployeeCommand() { EmployeeId = employeeId });

            return NoContent();
        }

        [HttpPut]
        [Route("api/editEmployee")]
        public async Task<IActionResult> EditEmployee([FromBody] EditEmployeeVm model)
        {
            await Mediator.Send(new EditEmployeeCommand() { Employee = model });

            return Ok();
        }
    }
}