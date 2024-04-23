using System;
using System.Threading.RateLimiting;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Business.IRepositories;
using E_Commerce.Business.IServices;
using E_Commerce.Business.Services;
using E_Commerce.Data.Context;
using E_Commerce.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => options.UseMySQL("server=localhost;database=instantgaming;user=root;password=19911974aA,aA;SslMode=none"));

// Ajoutez cette ligne pour tester la connexion à la base de données
TestDatabaseConnection(builder.Services);

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAchatsService, AchatService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddScoped<IClientRepository, DatabaseClientRepository>();
builder.Services.AddScoped<IAchatsRepository, DatabaseAchatsRepository>();
builder.Services.AddScoped<IAdminRepository, DatabaseAdminRepository>();
builder.Services.AddScoped<IProduitRepository, DatabaseProduitRepository>();
builder.Services.AddScoped<ISiteRepository, DatabaseSiteRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Méthode pour tester la connexion à la base de données
void TestDatabaseConnection(IServiceCollection services)
{
    try
    {
        // Créez un scope de service pour obtenir une instance de DbContext
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();

            // Testez la connexion à la base de données en exécutant une requête simple
            var isConnected = dbContext.Database.CanConnect();

            if (isConnected)
            {
                Console.WriteLine("La connexion à la base de données a réussi.");
            }
            else
            {
                Console.WriteLine("Échec de la connexion à la base de données.");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur lors de la connexion à la base de données : {ex.Message}");
    }
}
