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
        public required string Name { get; set; }

        [Required]
        public required AccessModifier AccessModifier { get; set; }

        [Required]
        public required MethodModifier MethodModifier { get; set; }

        [Required]
        public required string ReturnType { get; set; }
        public int ClassModelId { get; set; }

        [Required]
        public bool GetsInherited { get; set; }

        [JsonIgnore]
        public ClassModel? ClassModel { get; set; } = null!;
    }
}

public enum MethodModifier
{
    Default = 0,
    New,
    Virtual,
    Abstract,
    Sealed,
    Static
}
