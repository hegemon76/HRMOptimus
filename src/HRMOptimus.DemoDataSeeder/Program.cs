using HRMOptimus.DemoDataSeeder.Customizations;
using HRMOptimus.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace HRMOptimus.DemoDataSeeder
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), ex.Message);
                Environment.ExitCode = 1;
            }
        }

        private static void Execute()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
               .AddJsonFile("appsettings.json")
               .Build();

            var services = new ServiceCollection();
            services.AddCustomizations();
            services.AddPersistance(configuration);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                serviceProvider.GetService<DemoDataSeederCustomization>().Run();
            }
        }
    }
}