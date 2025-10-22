using Front.Services;
using Microsoft.AspNetCore.Components;

namespace Front.ViewModels
{
    public class AnimalCreateViewModel
    {
        private readonly AnimalService _animalService;
        private readonly NavigationManager _navigationManager;

        public AnimalViewModel Animal { get; set; }

        public AnimalCreateViewModel(AnimalService animalService, NavigationManager navigationManager)
        {
            _animalService = animalService;
            _navigationManager = navigationManager;
            Animal = new AnimalViewModel();
        }

        public async Task<bool> CreateAnimalAsync()
        {
            var result = await _animalService.CreateAnimalAsync(Animal);
            if (result)
            {
                _navigationManager.NavigateTo("/animals");
            }
            return result;
        }

        public void Cancel()
        {
            _navigationManager.NavigateTo("/animals");
        }
    }
}
