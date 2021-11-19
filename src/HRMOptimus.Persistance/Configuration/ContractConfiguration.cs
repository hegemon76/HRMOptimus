using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMOptimus.Persistance.Configuration
{
    public class ContractConfiguration : IEntityTypeConfiguration<Domain.Entities.Contract>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Contract> builder)
        {
            builder.Property(t => t.ContractName)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(t => t.LeaveDays)
                .HasPrecision(18, 2);
            builder.Property(t => t.Payment)
                .HasPrecision(18, 2);
            builder.Property(t => t.Rate)
                .HasPrecision(18, 2);
        }
    }
}