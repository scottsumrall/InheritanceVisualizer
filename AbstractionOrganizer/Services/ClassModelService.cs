using AbstractionOrganizer.Models;

namespace AbstractionOrganizer.Services
{
    public class ClassModelService : IClassModelService
    {
        private readonly HttpClient _httpClient;

        public ClassModelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ClassModel>> GetClassModels()
        {
            return await _httpClient.GetFromJsonAsync<ClassModel[]>("/api/classheader");
        }
    }
}
