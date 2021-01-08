using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Factory.Models{
  public class FactoryContextFactory : IDesignTimeDbContextFactory<FactoryContext>
  {
    ClinicContext IDesignTimeDbContextFactory<FactoryContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
      
      var builder = new DbContextOptionsBuilder<ClinicContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new ClinicContext(builder.Options);
    }
  }
}