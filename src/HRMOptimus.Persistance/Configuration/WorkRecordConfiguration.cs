using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMOptimus.Persistance.Configuration
{
    public class WorkRecordConfiguration : IEntityTypeConfiguration<Domain.Entities.WorkRecord>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.WorkRecord> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(150)
                .IsRequired(false);
            builder.Property(t => t.Duration)
                .HasPrecision(18, 2);
        }
    }
}