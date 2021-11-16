using HRMOptimus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMOptimus.Persistance.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(t => t.City)
                .HasMaxLength(50)
                .IsRequired(false);
            builder.Property(t => t.BuildingNumber)
                .HasMaxLength(15)
                .IsRequired(false);
            builder.Property(t => t.Country)
                .HasMaxLength(75)
                .IsRequired(false);
            builder.Property(t => t.Street)
                .HasMaxLength(75)
                .IsRequired(false);
            builder.Property(t => t.HouseNumber)
                .HasMaxLength(15)
                .IsRequired(false);
            builder.Property(t => t.ZipCode)
                .HasMaxLength(12)
                .IsRequired(false);
        }
    }
}