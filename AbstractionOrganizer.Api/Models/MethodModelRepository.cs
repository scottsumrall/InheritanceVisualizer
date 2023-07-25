using AbstractionOrganizer.Models;

namespace AbstractionOrganizer.Api.Models
{
	public class MethodModelRepository : IMethodModelRepository
	{
		public Task<MethodModel> AddMethodModel(MethodModel methodModel)
		{
			throw new NotImplementedException();
		}

		public Task<MethodModel> DeleteMethodModel(int methodModelId)
		{
			throw new NotImplementedException();
		}

		public Task<MethodModel> GetMethodModel(int methodModelId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<MethodModel>> GetMethodModels()
		{
			throw new NotImplementedException();
		}

		public Task<MethodModel> UpdateMethodModel(MethodModel classModel)
		{
			throw new NotImplementedException();
		}
	}
}
