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
builder.Services.AddDbContext<MyDbContext>(options => options.UseMySQL("server=localhost;database=instantgaming;user=root;password=19911974;SslMode=none;AllowPublicKeyRetrieval=True"));

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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin"); // Ajoutez le middleware CORS ici
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowSpecificOrigin");
app.Run();
