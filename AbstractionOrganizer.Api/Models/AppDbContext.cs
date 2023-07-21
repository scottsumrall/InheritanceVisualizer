using AbstractionOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AbstractionOrganizer.Api.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<ClassHeader> Games => Set<ClassHeader>();
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
