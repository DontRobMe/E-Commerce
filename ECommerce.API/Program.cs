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
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer("Server=tcp:ecommerceb2dev.database.windows.net,1433;Initial Catalog=instantgaming;Persist Security Info=False;User ID=gourbalo;Password=19911974aA,aA;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
        builder => builder.MigrationsAssembly(typeof(MyDbContext).Assembly.FullName)));

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

void TestDatabaseConnection(IServiceCollection services)
{
    try
    {
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();

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
