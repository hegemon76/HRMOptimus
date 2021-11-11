//using HRMOptimus.Application.Common.Interfaces;
//using MediatR;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace HRMOptimus.Application.WorkRecord.Command.AddWorkRecord
//{
//    class AddWorkRecordCommandHandler : IRequestHandler<AddWorkRecordCommand, string>
//    {
//        private readonly IHRMOptimusDbContext _context;

//        public AddWorkRecordCommandHandler(IHRMOptimusDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<string> Handle(AddWorkRecordCommand request, CancellationToken cancellationToken)
//        {
//            //try
//            //{
//            //    var duration = request.WorkRecordVm.WorkEnd.TimeOfDay - request.WorkRecordVm.WorkStart.TimeOfDay;
//            //    var employee = await _context.Employees.FindAsync(request.WorkRecordVm.EmployeeId);

//            //    Domain.Entities.WorkRecord workRecord = new Domain.Entities.WorkRecord()
//            //    {
//            //        Name = request.WorkRecordVm.Name,
//            //        WorkStart = request.WorkRecordVm.WorkStart,
//            //        WorkEnd = request.WorkRecordVm.WorkEnd,
//            //        Duration = duration,
//            //        ProjectId = request.WorkRecordVm.ProjectId,
//            //        EmployeeId = request.WorkRecordVm.EmployeeId
//            //    };
//            //    _context.WorkRecords.Add(workRecord);
//            //    employee.WorkRecords.Add(workRecord);
//            //    employee.WorkingTime += duration;

//            //    project.WorkRekords.Add(workRecord);

//            //    await _context.SaveChangesAsync(cancellationToken);
//            //}
//            //catch (Exception ex)
//            //{
//            //    return ex.ToString();
//            //}
//            //return  null;
//        }
//    }
//}
