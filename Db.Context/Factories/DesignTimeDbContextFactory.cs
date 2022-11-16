using Db.Context.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Db.Context.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            var options = new DbContextOptionsBuilder<MainDbContext>()
                          .UseSqlServer(configuration.GetConnectionString("MainDbContext"),
                                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                           ).Options;

            return new MainDbContextFactory(options).Create();
        }
    }
}
