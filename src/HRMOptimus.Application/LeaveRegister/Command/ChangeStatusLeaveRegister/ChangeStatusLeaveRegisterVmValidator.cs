using FluentValidation;
using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMOptimus.Application.LeaveRegister.Command.ChangeStatusLeaveRegister
{
    public class ChangeStatusLeaveRegisterVmValidator : AbstractValidator<ChangeStatusLeaveRegisterVm>
    {
        public ChangeStatusLeaveRegisterVmValidator(IHRMOptimusDbContext dbContext)
        {
            RuleFor(x => x.RecordId)
                .Custom((value, context) =>
                {
                    var leaveRecord = dbContext.LeavesRegister.Any(e => e.Id == value && e.Enabled);
                    if (!leaveRecord)
                        context.AddFailure("Id", "The Leave record with Id: " + value + " doesn't exist");
                });

            RuleFor(x => x.EmployeeId)
               .Custom((value, context) =>
               {
                   var employee = dbContext.Employees.Any(e => e.Id == value && e.Enabled);
                   if (!employee)
                       context.AddFailure("Id", "The Employee with Id: " + value + " doesn't exist");
               });
        }
    }
}