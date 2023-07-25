using AbstractionOrganizer.Models;

namespace AbstractionOrganizer.Api.Models
{
	public interface IClassModelRepository
	{
		Task<IEnumerable<ClassModel>> GetClassModels();

		Task<ClassModel> GetClassModel(int classModelId);

		Task<ClassModel> AddClassModel(ClassModel classModel);

		Task<ClassModel> DeleteClassModel(int classModelId);

		Task<ClassModel> UpdateClassModel(ClassModel classModel);
	}
}
