using AbstractionOrganizer.Api.Data;
using AbstractionOrganizer.Models;
using Microsoft.EntityFrameworkCore;

// [Program.cs]

var builder = WebApplication.CreateBuilder(args);

// TODO: Figure out why secret is causing issues
var conString = "Server=localhost;Database=AbstractionOrganizer;TrustServerCertificate=True;User Id=sa;Password=Pass@word1";//builder.Configuration.GetConnectionString("AppDbContext");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conString));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
