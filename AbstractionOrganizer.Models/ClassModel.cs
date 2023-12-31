﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

		//
		[Required]
		public required ClassModifier ClassModifier { get; set; }

		public virtual ICollection<VariableModel>? VariableModels { get; set; } = new List<VariableModel>();

        public virtual ICollection<MethodModel>? MethodModels { get; set; } = new List<MethodModel>();

        // One to many self referential relationship


        public int? ParentClassModelId { get; set; }
        [JsonIgnore]
        public ClassModel? ParentClassModel { get; set; } = null!;

        public virtual ICollection<ClassModel>? ChildClassModels { get; set; } = new List<ClassModel>();

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ClassModifier
	{
		Concrete = 0,
		Abstract,
		Static,
		Sealed
	}
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccessModifier
	{
		Public,
		Private,
		Protected,
		Internal,
	}
}