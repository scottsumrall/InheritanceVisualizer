using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AbstractionOrganizer.Models
{
	public class MethodModel
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        public required String Name { get; set; }

        [Required]
        public required AccessModifier AccessModifier { get; set; }

        [Required]
        public required MethodModifier MethodModifier { get; set; }

        public int ClassModelId { get; set; }

        [Required]
        public bool GetsInherited { get; set; }

        [JsonIgnore]
        public ClassModel? ClassModel { get; set; } = null!;
    }
}

public enum MethodModifier
{
    Defualt = 0,
    New,
    Virtual,
    Abstract,
    Sealed,
    Static
}
