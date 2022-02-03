using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Common;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Persistance
{
    public class HRMOptimusDbContext : IdentityDbContext<ApplicationUser>, IHRMOptimusDbContext
    {
        private readonly IUserContextService _userContextService;

        public HRMOptimusDbContext(DbContextOptions<HRMOptimusDbContext> options, IUserContextService userContextService)
            : base(options)
        {
            _userContextService = userContextService;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<LeaveRegister> LeavesRegister { get; set; }
        public DbSet<WorkRecord> WorkRecords { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _userContextService.GetEmployeeName;
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.LastModifiedOn = DateTime.Now;
                        entry.Entity.LastModifiedBy = _userContextService.GetEmployeeName;
                        entry.Entity.Enabled = true;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.Enabled = false;
                        entry.Entity.LastModifiedOn = DateTime.Now;
                        entry.Entity.LastModifiedBy = _userContextService.GetEmployeeName;
                        entry.Entity.InactivatedBy = _userContextService.GetEmployeeName;
                        entry.Entity.InactivatedOn = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.State = EntityState.Modified;
                        entry.Entity.LastModifiedBy = _userContextService.GetEmployeeName;
                        entry.Entity.LastModifiedOn = DateTime.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRMOptimusDbContext).Assembly);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = nameof(Domain.Enums.UserRoles.Administrator), NormalizedName = nameof(Domain.Enums.UserRoles.Administrator) },
                new IdentityRole { Name = nameof(Domain.Enums.UserRoles.User), NormalizedName = nameof(Domain.Enums.UserRoles.User) },
                new IdentityRole { Name = nameof(Domain.Enums.UserRoles.ProjectManager), NormalizedName = nameof(Domain.Enums.UserRoles.ProjectManager) },
                new IdentityRole { Name = nameof(Domain.Enums.UserRoles.HumanResources), NormalizedName = nameof(Domain.Enums.UserRoles.HumanResources) }
                );
        }
    }
}