using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionOrganizer.Models
{
	public class VariableModel
	{
		[Required]
		[Key]
		public required int Id { get; set; }

		[Required]
		public required String Name { get; set; }

		[Required]
		public required AccessModifier AccessModifier { get; set; }

		[Required]
		public required bool IsStatic { get; set; }
	}
}
