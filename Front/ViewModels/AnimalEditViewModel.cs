using Front.Services;
using Microsoft.AspNetCore.Components;

namespace Front.ViewModels
{
    public class AnimalEditViewModel
    {
        private readonly AnimalService _animalService;
        private readonly NavigationManager _navigationManager;

        public AnimalViewModel? Animal { get; private set; }
        public int AnimalId { get; set; }

        public AnimalEditViewModel(AnimalService animalService, NavigationManager navigationManager)
        {
            _animalService = animalService;
            _navigationManager = navigationManager;
        }

        public async Task LoadAnimalAsync(int id)
        {
            AnimalId = id;
            Animal = await _animalService.GetAnimalByIdAsync(id);
        }

        public async Task<bool> UpdateAnimalAsync()
        {
            if (Animal == null) return false;

            var result = await _animalService.UpdateAnimalAsync(AnimalId, Animal);
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
