using AbstractionOrganizer.Models;
using Microsoft.EntityFrameworkCore;

List<ClassHeader> classes = new List<ClassHeader>
{
	new ClassHeader
	{
		Id = 1,
		Name = "class1",
		AccessModifier = AccessModifier.Public,
		ClassModifier = ClassModifier.Concrete
	},

	new ClassHeader
	{
		Id = 2,
		Name = "class2",
		AccessModifier = AccessModifier.Protected,
		ClassModifier = ClassModifier.Concrete
	},

	new ClassHeader
	{
		Id = 3,
		Name = "class3",
		AccessModifier = AccessModifier.Protected,
		ClassModifier = ClassModifier.Abstract
	},

	new ClassHeader
	{
		Id = 4,
		Name = "class4",
		AccessModifier = AccessModifier.Private,
		ClassModifier = ClassModifier.Static
	}
};

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("GameStoreContext");

// Regester the dbContext (GameStoreContext) for dependency injection
builder.Services.AddSqlServer<DbContext>(conString);

// Add services to the container.

builder.Services.AddControllers();
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
