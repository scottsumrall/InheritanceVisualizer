using AbstractionOrganizer.Models;

namespace AbstractionOrganizer.Api.Models
{
	public interface IMethodModelRepository
	{
		Task<IEnumerable<MethodModel>> GetMethodModels();

		Task<MethodModel> GetMethodModel(int methodModelId);

		Task<MethodModel> AddMethodModel(MethodModel methodModel);

		Task<MethodModel> DeleteMethodModel(int methodModelId);

		Task<MethodModel> UpdateMethodModel(MethodModel classModel);
	}
}
