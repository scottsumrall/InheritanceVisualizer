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
            ClassModel[]? result = await _httpClient.GetFromJsonAsync<ClassModel[]>("/api/classheader");

            if (result is not null)
            {
                return result;
            }

            return Enumerable.Empty<ClassModel>();

		}
    }
}
