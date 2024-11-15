using Example.ApplicationLayer.Interfaces;
using Example.ApplicationLayer.Service;
using Example.DatabaseLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// appsettings.json dosyasındaki "DefaultConnection" anahtarını alıyoruz
var connectionString = builder.Configuration.GetConnectionString("MssqlMy");

// Add services to the container.
builder.Services.AddControllers();
// Swagger ve API açıklamaları
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext'i yapılandırmak ve connection string'i kullanmak
builder.Services.AddDbContext<ExampleAppContext>(options =>
    options.UseSqlServer(connectionString) // Burada connection string'i kullanıyoruz
);

builder.Services.AddTransient<ICityService,CityService>();
builder.Services.AddTransient<IDistrictService,DistrictService>();
// Bağlantıyı test etmek için eklediğimiz kod
var app = builder.Build();


// Veritabanı bağlantısının başarılı olup olmadığını kontrol et
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ExampleAppContext>();
    try
    {
        // Veritabanına bağlanmayı test et
        if (context.Database.CanConnect())
        {
            Console.WriteLine("Db Connect Success");
        }
        else
        {
            Console.WriteLine("Db Connect Failure");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Db Connect Failure: {ex.Message}");
    }
}

// Swagger'ın etkinleştirilmesi
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
