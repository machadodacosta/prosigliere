using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Prosigliere.Challenge.ORM;

namespace Prosigliere.Challenge.WebApi
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();

            builder.UseNpgsql(
                config.GetConnectionString("Database"),
                b => b.MigrationsAssembly("Prosigliere.Challenge.WebApi")
            );

            return new AppDbContext(builder.Options);
        }
    }
}
