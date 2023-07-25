using AbstractionOrganizer.Models;

namespace AbstractionOrganizer.Services
{
    public interface IClassModelService
    {
        Task<IEnumerable<ClassModel>> GetClassModels();
    }
}
