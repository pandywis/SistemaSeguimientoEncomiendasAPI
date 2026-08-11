using Microsoft.EntityFrameworkCore;
using Encomiendas.Infrastructure.Context;
using SistemaSeguimientoEncomiendas.Application.Contract;
using SistemaSeguimientoEncomiendas.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de tus servicios de la capa Application
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPaqueteService, PaqueteService>(); // <-- AGREGADO AQUÍ
builder.Services.AddScoped<SistemaSeguimientoEncomiendas.Application.Contract.IReporteService, SistemaSeguimientoEncomiendas.Application.Services.ReporteService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();