using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Domain.Common;
using HRMOptimus.Domain.Entities;
using HRMOptimus.Domain.Enums;
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
        public HRMOptimusDbContext(DbContextOptions<HRMOptimusDbContext> options)
            : base(options)
        { }

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
                        entry.Entity.CreatedBy = "1";
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.Enabled = true;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.Enabled = false;
                        entry.Entity.LastModifiedOn = DateTime.Now;
                        entry.Entity.InactivatedBy = "1";
                        break;

                    case EntityState.Modified:
                        entry.State = EntityState.Modified;
                        entry.Entity.LastModifiedBy = "1";
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
                new IdentityRole { Name = Domain.Enums.UserRoles.Administrator.ToString(), NormalizedName = Domain.Enums.UserRoles.Administrator.ToString() },
                new IdentityRole { Name = Domain.Enums.UserRoles.User.ToString(), NormalizedName = Domain.Enums.UserRoles.User.ToString() }
                );
        }
    }
}