using Example.ApplicationLayer.Interfaces;
using Example.ApplicationLayer.Service;
using Example.DatabaseLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// appsettings.json dosyas�ndaki "DefaultConnection" anahtar�n� al�yoruz
var connectionString = builder.Configuration.GetConnectionString("MssqlMy");

// Add services to the container.
builder.Services.AddControllers();
// Swagger ve API a��klamalar�
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext'i yap�land�rmak ve connection string'i kullanmak
builder.Services.AddDbContext<ExampleAppContext>(options =>
    options.UseSqlServer(connectionString) // Burada connection string'i kullan�yoruz
);

builder.Services.AddTransient<ICityService,CityService>();
builder.Services.AddTransient<IDistrictService,DistrictService>();
// Ba�lant�y� test etmek i�in ekledi�imiz kod
var app = builder.Build();


// Veritaban� ba�lant�s�n�n ba�ar�l� olup olmad���n� kontrol et
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ExampleAppContext>();
    try
    {
        // Veritaban�na ba�lanmay� test et
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

// Swagger'�n etkinle�tirilmesi
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
