using AbstractionOrganizer.Models;

namespace AbstractionOrganizer.Services
{
    public interface IClassModelService
    {
        Task<IEnumerable<ClassModel>> GetClassModels();

        Task<ClassModel> GetClassModel(int id);
    }
}
