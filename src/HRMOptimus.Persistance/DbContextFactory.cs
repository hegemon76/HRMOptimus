using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Common.Services;
using Microsoft.EntityFrameworkCore;

namespace HRMOptimus.Persistance
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<HRMOptimusDbContext>
    {
        //public DbContextFactory(IUserContextService userContextService) : base(userContextService)
        //{
        //}

        protected override HRMOptimusDbContext CreateNewInstance(DbContextOptions<HRMOptimusDbContext> options)
        {
            return new HRMOptimusDbContext(options);
        }

        //protected override HRMOptimusDbContext CreateNewInstance(DbContextOptions<HRMOptimusDbContext> options, IUserContextService userContextService)
        //{
        //    return new HRMOptimusDbContext(options, userContextService);
        //}
    }
}