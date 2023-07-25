using AbstractionOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AbstractionOrganizer.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        } 

        public DbSet<ClassModel> ClassHeaders => Set<ClassModel>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ClassModel>().HasData(new ClassModel
			{
				Id = 1,
				Name = "class1",
				AccessModifier = AccessModifier.Public,
				ClassModifier = ClassModifier.Concrete
			});

			modelBuilder.Entity<ClassModel>().HasData(new ClassModel
			{
				Id = 2,
				Name = "class2",
				AccessModifier = AccessModifier.Protected,
				ClassModifier = ClassModifier.Concrete
			});

			modelBuilder.Entity<ClassModel>().HasData(new ClassModel
			{
				Id = 3,
				Name = "class3",
				AccessModifier = AccessModifier.Protected,
				ClassModifier = ClassModifier.Abstract
			});

			modelBuilder.Entity<ClassModel>().HasData(new ClassModel
			{
				Id = 4,
				Name = "class4",
				AccessModifier = AccessModifier.Private,
				ClassModifier = ClassModifier.Static
			});

        }
    }
}
