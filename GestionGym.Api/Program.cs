using Amazon.Runtime;
using Amazon.S3;
using GestionGym.AccesoDatos.Contexto;
using GestionGym.Dto.Request.Aws;
using GestionGym.Repositorios.Interfaces;
using GestionGym.Servicios.Interfaces;
using GestionGym.Servicios.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string corsConfiguracion = "SmartGym";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Vincular la configuración de AWS al modelo AWSOptions
builder.Services.Configure<AwsOptions>(builder.Configuration.GetSection("AWS"));

// Configurar el cliente Amazon S3
builder.Services.AddSingleton<IAmazonS3>(sp =>
{
    var awsOptions = sp.GetRequiredService<IOptions<AwsOptions>>().Value;
    var credentials = new BasicAWSCredentials(awsOptions.AccessKeyId, awsOptions.SecretAccessKey);
    return new AmazonS3Client(credentials, Amazon.RegionEndpoint.GetBySystemName(awsOptions.Region));
});

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
