using System.Reflection;
using API.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureCors();
builder.Services.AddAplicationServices();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.ConfigureRateLimiting();
builder.Services.ConsigureApiVersioning();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SistemReporteContext>(OptionsBuilder =>{
    string ? ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    OptionsBuilder.UseMySql(ConnectionString,ServerVersion.AutoDetect(ConnectionString));

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseApiVersioning();
app.UseIpRateLimiting();//Aqui ya le estoy enviando a mi core de mi Backend 
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
