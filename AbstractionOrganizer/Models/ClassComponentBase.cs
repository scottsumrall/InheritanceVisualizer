using Microsoft.AspNetCore.Components;

namespace AbstractionOrganizer.Models
{
	public class ClassComponentBase : ComponentBase
	{
		public List<ClassHeader> classes = new List<ClassHeader>
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
	}
}
