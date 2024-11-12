using Example.ApplicationLayer.Interfaces;
using Example.ApplicationLayer.Service;
using Example.DatabaseLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// appsettings.json dosyasýndaki "DefaultConnection" anahtarýný alýyoruz
var connectionString = builder.Configuration.GetConnectionString("MssqlMy");

// Add services to the container.
builder.Services.AddControllers();
// Swagger ve API açýklamalarý
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext'i yapýlandýrmak ve connection string'i kullanmak
builder.Services.AddDbContext<ExampleAppContext>(options =>
    options.UseSqlServer(connectionString) // Burada connection string'i kullanýyoruz
);

builder.Services.AddTransient<ICityService,CityService>();
builder.Services.AddTransient<IDistrictService,DistrictService>();
// Baðlantýyý test etmek için eklediðimiz kod
var app = builder.Build();


// Veritabaný baðlantýsýnýn baþarýlý olup olmadýðýný kontrol et
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ExampleAppContext>();
    try
    {
        // Veritabanýna baðlanmayý test et
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

// Swagger'ýn etkinleþtirilmesi
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
