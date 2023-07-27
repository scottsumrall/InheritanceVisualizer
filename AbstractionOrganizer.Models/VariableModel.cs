using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AbstractionOrganizer.Models
{
	public class VariableModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public required int Id { get; set; }

		[Required]
		public required String Name { get; set; }

		[Required]
		public required AccessModifier AccessModifier { get; set; }

		[Required]
		public required bool IsStatic { get; set; }

		public int ClassModelId { get; set; }
		[JsonIgnore]
		public ClassModel? ClassModel { get; set; } = null!;
	}
}
