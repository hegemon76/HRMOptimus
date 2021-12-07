using Microsoft.EntityFrameworkCore;

namespace HRMOptimus.Persistance
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<HRMOptimusDbContext>
    {
        protected override HRMOptimusDbContext CreateNewInstance(DbContextOptions<HRMOptimusDbContext> options)
        {
            return new HRMOptimusDbContext(options);
        }
    }
}