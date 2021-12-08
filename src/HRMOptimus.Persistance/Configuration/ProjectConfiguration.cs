using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMOptimus.Persistance.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Domain.Entities.Project>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Project> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(60)
                .IsRequired(false);
            builder.Property(t => t.Description)
                .HasMaxLength(150)
                .IsRequired(false);
            builder.Property(t => t.ColorLabel)
               .HasMaxLength(50)
               .IsRequired(false);
            builder.Property(t => t.HoursBudget)
                .HasPrecision(18, 2);
            builder.Property(t => t.HoursWorked)
                .HasPrecision(18, 2);
        }
    }
}