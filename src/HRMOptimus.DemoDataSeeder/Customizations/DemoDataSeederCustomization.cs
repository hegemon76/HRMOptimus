using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.DemoDataSeeder.Commands;

namespace HRMOptimus.DemoDataSeeder.Customizations
{
    public class DemoDataSeederCustomization
    {
        internal readonly IHRMOptimusDbContext _context;

        public DemoDataSeederCustomization(IHRMOptimusDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            new SeedUsers(this).Execute();
        }
    }
}