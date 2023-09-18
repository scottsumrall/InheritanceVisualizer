using AbstractionOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

		public DbSet<MethodModel> MethodModels => Set<MethodModel>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ClassModel>()
			.HasMany(c => c.VariableModels)
			.WithOne(c => c.ClassModel)
			.HasForeignKey(c => c.ClassModelId)
			.IsRequired();

			modelBuilder.Entity<ClassModel>()
			.HasOne(x => x.ParentClassModel)
			.WithMany(x => x.ChildClassModels)
			.HasForeignKey(x => x.ParentClassModelId)
            .OnDelete(DeleteBehavior.Restrict);


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType.BaseType == typeof(Enum))
                    {
                        var type = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
                        var converter = Activator.CreateInstance(type, new ConverterMappingHints()) as ValueConverter;

                        property.SetValueConverter(converter);
                    }
                }
            }


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
					Type = "Int",
					AccessModifier = AccessModifier.Public,
					IsStatic = false,
					ClassModelId = 1
				},
				new VariableModel()
				{
					Id = 2,
					Name = "testVar2",
					Type = "String",
					AccessModifier = AccessModifier.Private,
					IsStatic = false,
					ClassModelId = 1
				}
			};

			var methodModelList = new List<MethodModel>
			{ 
				new MethodModel()
				{
					Id=1,
					Name="testMethod1",
					ReturnType = "void",
					AccessModifier = AccessModifier.Public,
					MethodModifier=MethodModifier.Static,
					ClassModelId= 1,
					GetsInherited=true
				}
			};



			//classModelList![0].VariableModels.Add(variableModelList[0]);
			//classModelList![0].VariableModels.Add(variableModelList[1]);

			modelBuilder.Entity<ClassModel>().HasData(classModelList);
			modelBuilder.Entity<VariableModel>().HasData(variableModelList);
			modelBuilder.Entity<MethodModel>().HasData(methodModelList);
		}
	}
}
