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
            if (user != null)
            {
                var updatedApplicationUser = user.ApplicationUser;
                updatedApplicationUser.PhoneNumber =
                    !string.IsNullOrWhiteSpace(request.Employee.PhoneNumber) ? request.Employee.PhoneNumber : updatedApplicationUser.PhoneNumber;

                var updatedEmployee = user;
                updatedEmployee.FirstName =
                    !string.IsNullOrWhiteSpace(request.Employee.FirstName) ? request.Employee.FirstName : updatedEmployee.FirstName;

                updatedEmployee.LastName =
                   !string.IsNullOrWhiteSpace(request.Employee.LastName) ? request.Employee.LastName : updatedEmployee.LastName;

                updatedEmployee.BirthDate =
                    request.Employee.BirthDate.HasValue ? request.Employee.BirthDate.Value : updatedEmployee.BirthDate;

                updatedEmployee.Gender =
                    request.Employee.Gender.HasValue ? request.Employee.Gender.Value : updatedEmployee.Gender;


                var updatedAddress = updatedEmployee.Address;

                updatedAddress.ZipCode =
                   !string.IsNullOrWhiteSpace(request.Employee.ZipCode) ? request.Employee.ZipCode : updatedAddress.ZipCode;

                updatedAddress.City =
                  !string.IsNullOrWhiteSpace(request.Employee.City) ? request.Employee.City : updatedAddress.City;

                updatedAddress.Street =
                  !string.IsNullOrWhiteSpace(request.Employee.Street) ? request.Employee.Street : updatedAddress.Street;

                updatedAddress.BuildingNumber =
                  !string.IsNullOrWhiteSpace(request.Employee.BuildingNumber) ? request.Employee.BuildingNumber : updatedAddress.BuildingNumber;

                updatedAddress.HouseNumber =
                  !string.IsNullOrWhiteSpace(request.Employee.HouseNumber) ? request.Employee.HouseNumber : updatedAddress.HouseNumber;

                updatedAddress.Country =
                  !string.IsNullOrWhiteSpace(request.Employee.Country) ? request.Employee.Country : updatedAddress.Country;


                var employee = _context.Employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);

                _context.Employees.Update(updatedEmployee);
                _context.Addresses.Update(updatedEmployee.Address);
                _context.ApplicationUsers.Update(updatedApplicationUser);

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            return Unit.Value;
        }
    }
}