using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMOptimus.Persistance.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Domain.Entities.Employee>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Employee> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(t => t.LastName)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(t => t.FullName)
                .HasMaxLength(100)
                .IsRequired(false);
            builder.Property(t => t.LeaveDaysLeft)
                .HasPrecision(18, 2);
            builder.Property(t => t.WorkingTime)
                .HasPrecision(18, 2);
        }
    }
}