using GestionGym.AccesoDatos.Contexto;
using GestionGym.Repositorios.Interfaces;
using GestionGym.Servicios.Interfaces;
using GestionGym.Servicios.Mappers;
using Microsoft.EntityFrameworkCore;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string corsConfiguracion = "SmartGym";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Se agregan las configuraciones del CORS
builder.Services.AddCors(policy =>
{
    policy.AddPolicy(corsConfiguracion, config =>
    {
        config.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<BdGymContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("bdgym"));
});

// Registramos las dependencias de Repositories y Services (SCRUTOR)
builder.Services.Scan(selector => selector
    .FromAssemblies(typeof(IMaestroRepository).Assembly,
        typeof(IMaestroService).Assembly)
    .AddClasses(false)
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsMatchingInterface()
    .WithScopedLifetime());

builder.Services.AddAutoMapper(config =>
{
    config.AddMaps(typeof(MaestroProfile).Assembly);
});

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

app.UseCors(corsConfiguracion);

app.Run();
