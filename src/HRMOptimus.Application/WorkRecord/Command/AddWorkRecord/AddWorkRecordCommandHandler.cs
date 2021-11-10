using HRMOptimus.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HRMOptimus.Domain.Entities;
using System.Threading.Tasks;

namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
{
    class AddWorkRecordCommandHandler : IRequestHandler<AddWorkRecordCommand, string>
    {
        private readonly IHRMOptimusDbContext _context;

        public AddWorkRecordCommandHandler(IHRMOptimusDbContext context)
        {
            _context = context;
        }
        //public async Task<string> Handle(AddWorkRecordCommand request, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var duration = request.WorkRecordVm.WorkEnd.TimeOfDay - request.WorkRecordVm.WorkStart.TimeOfDay;
        //        var project = await _context.Projects.FindAsync(request.WorkRecordVm.ProjectId);
        //        var employee = await _context.Employees.FindAsync(request.WorkRecordVm.EmployeeId);

        //        Domain.Entities.WorkRecord workRecord = new Domain.Entities.WorkRecord()
        //        {
        //            Name = request.WorkRecordVm.Name,
        //            WorkStart = request.WorkRecordVm.WorkStart,
        //            WorkEnd = request.WorkRecordVm.WorkEnd,
        //            Duration = duration,
        //            ProjectId = request.WorkRecordVm.ProjectId,
        //            Project = project,
        //            Employee = employee
        //        };
        //        _context.WorkRecords.Add(workRecord);
        //        employee.WorkRecords.Add(workRecord);
        //        employee.WorkingTime += duration;

        //        project.WorkRekords.Add(workRecord);

        //        await _context.SaveChangesAsync(cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}
    }
}
