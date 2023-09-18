using AbstractionOrganizer.Models;

namespace AbstractionOrganizer.Services
{
    public interface IMethodModelService
    {
        Task<IEnumerable<ClassModel>> GetMethodModels();

        Task<ClassModel> GetMethodModel(int id);

    }
}

