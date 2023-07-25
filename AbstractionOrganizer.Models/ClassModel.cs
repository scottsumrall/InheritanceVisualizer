using System.ComponentModel.DataAnnotations;

namespace AbstractionOrganizer.Models
{
	public class ClassModel
	{
		[Required]
		[Key]
		public required int Id { get; set; }

		[Required]
		public required String Name { get; set; }

		[Required]
		public required AccessModifier AccessModifier { get; set; }

		[Required]
		public required ClassModifier ClassModifier { get; set; }

		public ICollection<VariableModel>? VariableModels { get; set; }

	}

	public enum ClassModifier
	{
		Concrete = 0,
		Abstract,
		Static,
		Sealed
	}

	public enum AccessModifier
	{
		Public = 0,
		Private,
		Protected,
		Internal,
	}
}