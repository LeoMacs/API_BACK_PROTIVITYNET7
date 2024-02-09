using AirportApi.DataAccess.Data;
using AirportApi.DataAccess.Implementacion;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//////////////////////////////////////////
builder.Services.AddSingleton<ConexionService>();
builder.Services.AddSingleton<AirportDAO>();
/////////ENTITY FRAMEWORK-INYECCION DE DEPENDENCIAS/////////////////
builder.Services.AddDbContext<AppDBContext>(Options =>
{
	Options.UseSqlServer(builder.Configuration.GetConnectionString("BackendConexion"));
});
//////////////////////////////////////////////////////////////////

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
