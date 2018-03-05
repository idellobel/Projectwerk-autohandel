using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Autohandel.Domain.Data
{
    class AutohandelContextFactory : IDesignTimeDbContextFactory<AutohandelContext>
    {
        public AutohandelContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AutohandelContext>();
            var connectionString = configuration.GetConnectionString("AutohandelDb");
            builder.UseSqlServer(connectionString);
            return new AutohandelContext(builder.Options);
        }
    }
}
