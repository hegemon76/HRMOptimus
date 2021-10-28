using Microsoft.EntityFrameworkCore;
using System;

namespace HRMOptimus.Persistance
{
    public static class Seeder
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EntityName>(d =>
            //{
            //    d.HasData(new EntityName()
            //    {
            //        Id = 1,
            //        StatusId = 1,
            //        Created = DateTime.Now
            //    });
            //    d.OwnsOne(d => d.DirectorName).HasData(new { DirectorId = 1, FirstName = "Andrzej", LastName = "Wajda" });
            //}
            //    );

            //modelBuilder.Entity<EntityName>().HasData(
            //    new EntityName() { Id = 1, DirectorId = 1, Name = "Pan Tadeusz" },
            //    new EntityName() { Id = 2, DirectorId = 1, Name = "Popiół i Diament" }
            //    );
        }
    }
}
