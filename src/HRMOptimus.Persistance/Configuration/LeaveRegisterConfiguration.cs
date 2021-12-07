using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMOptimus.Persistance.Configuration
{
    public class LeaveRegisterConfiguration : IEntityTypeConfiguration<Domain.Entities.LeaveRegister>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.LeaveRegister> builder)
        {
            builder.Property(t => t.Duration)
                .HasPrecision(18, 2);
        }
    }
}