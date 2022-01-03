using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Employee.Command.EditEmployee
{
    public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHRMOptimusDbContext _context;

        public EditEmployeeCommandHandler(UserManager<ApplicationUser> userManager, IHRMOptimusDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Unit> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Employees.Include(a => a.Address)
                .Include(app => app.ApplicationUser)
                .FirstOrDefault(x => x.Id == request.Employee.EmployeeId);
            if(user != null)
            {
                var updatedApplicationUser = user.ApplicationUser;
                updatedApplicationUser.PhoneNumber = request.Employee.PhoneNumber;

                var updatedEmployee = user;
                updatedEmployee.FirstName = request.Employee.FirstName;
                updatedEmployee.LastName = request.Employee.LastName;
                updatedEmployee.BirthDate = request.Employee.BirthDate;
                updatedEmployee.Gender = request.Employee.Gender;

                var updatedAddress = updatedEmployee.Address;
                updatedAddress.ZipCode = request.Employee.ZipCode;
                updatedAddress.City = request.Employee.City;
                updatedAddress.Street = request.Employee.Street;
                updatedAddress.BuildingNumber = request.Employee.BuildingNumber;
                updatedAddress.HouseNumber = request.Employee.HouseNumber;
                updatedAddress.Country = request.Employee.Country;

                var employee = _context.Employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
                employee = updatedEmployee;
                

                var address = _context.Addresses.FirstOrDefault(a => a.Id == updatedAddress.Id);
                address = updatedAddress;
                
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            return Unit.Value;
        }
    }
}