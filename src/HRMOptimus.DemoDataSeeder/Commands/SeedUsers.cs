using HRMOptimus.DemoDataSeeder.Common.Interfaces;
using HRMOptimus.DemoDataSeeder.Customizations;
using HRMOptimus.Domain.Entities;
using System.Collections.Generic;

namespace HRMOptimus.DemoDataSeeder.Commands
{
    public class SeedUsers : ICustomiseCommand
    {
        private readonly DemoDataSeederCustomization _demoDataSeederCustomization;

        public SeedUsers(DemoDataSeederCustomization demoDataSeederCustomization)
        {
            _demoDataSeederCustomization = demoDataSeederCustomization;
        }

        public void Execute()
        {
            PopulateAddressData();
        }

        private void PopulateAddressData()
        {
            _demoDataSeederCustomization._context.ApplicationUsers.AddRange(NemDemoUsers());
        }

        private IEnumerable<ApplicationUser> NemDemoUsers()
        {
            System.Console.WriteLine("I am here");
            return new List<ApplicationUser>();
        }
    }
}