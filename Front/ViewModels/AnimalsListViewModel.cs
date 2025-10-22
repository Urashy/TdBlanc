using Front.Services;
using Microsoft.AspNetCore.Components;

namespace Front.ViewModels
{
    public class AnimalsListViewModel
    {
        private readonly AnimalService _animalService;
        private readonly NavigationManager _navigationManager;

        public List<AnimalViewModel>? Animals { get; private set; }

        public AnimalsListViewModel(AnimalService animalService, NavigationManager navigationManager)
        {
            _animalService = animalService;
            _navigationManager = navigationManager;
        }

        public async Task LoadAnimalsAsync()
        {
            Animals = await _animalService.GetAllAnimalsAsync();
        }

        public void NavigateToCreate()
        {
            _navigationManager.NavigateTo("/animals/create");
        }

        public void NavigateToEdit(int id)
        {
            _navigationManager.NavigateTo($"/animals/edit/{id}");
        }

        public async Task DeleteAnimalAsync(int id)
        {
            if (await _animalService.DeleteAnimalAsync(id))
            {
                await LoadAnimalsAsync();
            }
        }
    }
}
