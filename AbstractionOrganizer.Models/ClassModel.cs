using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractionOrganizer.Models
{
	public class ClassModel
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public required int Id { get; set; }

		[Required]
		public required String Name { get; set; }

		[Required]
		public required AccessModifier AccessModifier { get; set; }

		[Required]
		public required ClassModifier ClassModifier { get; set; }

		public virtual ICollection<VariableModel>? VariableModels { get; set; } = new List<VariableModel>();
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