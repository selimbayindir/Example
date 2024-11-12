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
            var connectionString2 = configuration.GetConnectionString("MssqlMy"); 

            // DbContextOptionsBuilder ile DbContext'i yapılandırıyoruz
            var optionsBuilder = new DbContextOptionsBuilder<ExampleAppContext>();
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSqlServer(connectionString2);

            return new ExampleAppContext(optionsBuilder.Options);
        }
    }
}


