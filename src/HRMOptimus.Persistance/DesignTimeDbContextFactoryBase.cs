using HRMOptimus.Application.Common.Interfaces;
using HRMOptimus.Application.Common.Services;
using HRMOptimus.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace HRMOptimus.Persistance
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "ConnectionStringName";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
        //private readonly IUserContextService _userContextService;

        //public DesignTimeDbContextFactoryBase(IUserContextService userContextService)
        //{
        //    _userContextService = userContextService;
        //}

        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}HRMOptimus.WebAPI", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        //protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options, IUserContextService userContextService);

        private TContext Create(string basePath, string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
            //return CreateNewInstance(optionsBuilder.Options, _userContextService);
        }
    }
}