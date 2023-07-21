using AbstractionOrganizer.Models;

namespace AbstractionOrganizer.Api.Models
{
	public interface IClassHeaderRepository
	{
		Task<IEnumerable<ClassHeader>> GetEmployees();

		Task<ClassHeader> GetClassHeader(int classHeaderId);

		Task<ClassHeader> AddEmployee(ClassHeader classHeader);

		void DeleteEmployee(int classHeaderId);


	}
}
