// using Microsoft.EntityFrameworkCore;
using Auth.Context;
using Auth.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexion a sql server
builder.Services.AddSqlServer<PersonContext>(builder.Configuration.GetConnectionString("cnbbienes"));

// TODO : Servicio de USUARIOS
builder.Services.AddScoped<IUserService,UserService>();

// TODO : Servicio de CLIENTES

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
