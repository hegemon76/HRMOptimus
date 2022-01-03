using HRMOptimus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Common.Interfaces
{
    public interface IHRMOptimusDbContext
    {
        public DbSet<Domain.Entities.Project> Projects { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Domain.Entities.Contract> Contracts { get; set; }
        public DbSet<Domain.Entities.Employee> Employees { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Domain.Entities.LeaveRegister> LeavesRegister { get; set; }
        public DbSet<Domain.Entities.WorkRecord> WorkRecords { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}