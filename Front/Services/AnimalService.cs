using Front.ViewModels;

namespace Front.Services
{
    public class AnimalService
    {
        private readonly HttpClient _httpClient;

        public AnimalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AnimalViewModel>> GetAllAnimalsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<AnimalViewModel>>("api/Animals")
                   ?? new List<AnimalViewModel>();
        }

        public async Task<AnimalViewModel?> GetAnimalByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<AnimalViewModel>($"api/Animals/{id}");
        }

        public async Task<bool> CreateAnimalAsync(AnimalViewModel animal)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Animals", animal);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAnimalAsync(int id, AnimalViewModel animal)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Animals/{id}", animal);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAnimalAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Animals/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
