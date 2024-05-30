using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FirmaSiparisYonetimSistemi.Data;
using FirmaSiparisYonetimSistemi.Repositories;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IFirmaRepository, FirmaRepository>(); // firma için baðýmlýlýk injeksiyonu
builder.Services.AddScoped<IUrunRepository, UrunRepository>(); // urun için 
builder.Services.AddScoped<ISiparisRepository, SiparisRepository>(); // siparis için

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FirmaSiparisYonetimSistemi", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FirmaSiparisYonetimSistemi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
