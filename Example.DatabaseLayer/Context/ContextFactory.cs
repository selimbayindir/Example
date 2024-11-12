using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Example.DatabaseLayer.Context
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<ExampleAppContext>
    {
        public ExampleAppContext CreateDbContext(string[] args)
        {
            // IConfiguration'ı kullanarak appsettings.json dosyasını okuyoruz
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Proje dizini
                .AddJsonFile("appsettings.json") // appsettings.json dosyasını yükle
                .Build();

            // Connection string'i appsettings.json'dan alıyoruz
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // DbContextOptionsBuilder ile DbContext'i yapılandırıyoruz
            var optionsBuilder = new DbContextOptionsBuilder<ExampleAppContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ExampleAppContext(optionsBuilder.Options);
        }
    }
}


/*
 *   "ConnectionStrings": {
    "MssqlWorks": "Server=SELIMBAYINDIR\\SUPERHERO;Database=NZWaLKS;User Id=sa;Password=PerUpdate28;Trusted_Connection=True;TrustServerCertificate=True",
    "MssqlMy": "Server=SELIM\\BYNDR;Database=NZWaLKS;User Id=sa;Password=Perkon123456;Trusted_Connection=True;TrustServerCertificate=True"
  }
 * 
 */