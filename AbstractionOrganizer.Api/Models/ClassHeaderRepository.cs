using AbstractionOrganizer.Models;

namespace AbstractionOrganizer.Api.Models
{
	public class ClassHeaderRepository : IClassHeaderRepository
	{
		private readonly AppDbContext _appDbContext;

		public ClassHeaderRepository(AppDbContext appDbContext) 
		{
			this._appDbContext = appDbContext;
		}

		public Task<ClassHeader> AddEmployee(ClassHeader classHeader)
		{
			throw new NotImplementedException();
		}

		public void DeleteEmployee(int classHeaderId)
		{
			throw new NotImplementedException();
		}

		public Task<ClassHeader> GetClassHeader(int classHeaderId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ClassHeader>> GetEmployees()
		{
			throw new NotImplementedException();
		}
	}
}
