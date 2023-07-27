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
		public DbSet<VariableModel> VariableModels => Set<VariableModel>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ClassModel>()

			.HasMany(c => c.VariableModels)
			.WithOne(c => c.ClassModel)
			.HasForeignKey(c => c.ClassModelId)
			.IsRequired();



			var classModelList = new List<ClassModel>
			{
				new ClassModel
				{
					Id = 1,
					Name = "class1",
					AccessModifier = AccessModifier.Public,
					ClassModifier = ClassModifier.Concrete,
				},

				new ClassModel
				{
					Id = 2,
					Name = "class2",
					AccessModifier = AccessModifier.Protected,
					ClassModifier = ClassModifier.Concrete
				},

				new ClassModel
				{
					Id = 3,
					Name = "class3",
					AccessModifier = AccessModifier.Protected,
					ClassModifier = ClassModifier.Abstract
				},

				new ClassModel
				{
					Id = 4,
					Name = "class4",
					AccessModifier = AccessModifier.Private,
					ClassModifier = ClassModifier.Static
				},
			};

			var variableModelList = new List<VariableModel>
			{
				new VariableModel()
				{
					Id = 1,
					Name = "testVar1",
					AccessModifier = AccessModifier.Public,
					IsStatic = false,
					ClassModelId = 1
				},
				new VariableModel()
				{
					Id = 2,
					Name = "testVar2",
					AccessModifier = AccessModifier.Private,
					IsStatic = false,
					ClassModelId = 1
				}
			};


			//classModelList![0].VariableModels.Add(variableModelList[0]);
			//classModelList![0].VariableModels.Add(variableModelList[1]);

			modelBuilder.Entity<ClassModel>().HasData(classModelList);
			modelBuilder.Entity<VariableModel>().HasData(variableModelList);
		}
	}
}
