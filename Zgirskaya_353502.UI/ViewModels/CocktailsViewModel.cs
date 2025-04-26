using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Zgirskaya_353502.Application.CocktailUseCases.Commands;
using Zgirskaya_353502.Application.CocktailUseCases.Queries;
using Zgirskaya_353502.Application.IngredientUseCases.Commands;
using Zgirskaya_353502.Application.IngredientUseCases.Queries;
using Zgirskaya_353502.Domain.Entities;
using Zgirskaya_353502.UI.Pages;

namespace Zgirskaya_353502.UI.ViewModels
{
    public partial class CocktailsViewModel(IMediator mediator) : ObservableObject
    {
        [ObservableProperty] private Cocktail? selectedCocktail;

        public ObservableCollection<Cocktail> ListOfCocktails { get; } = new();
        public ObservableCollection<Ingredient> ListOfIngredients { get; } = new();

        [RelayCommand]
        public async Task OnAppearing()
        {
            await LoadCocktails();
            await UpdateIngredients();
        }

        [RelayCommand]
        private async Task LoadCocktails()
        {
            ListOfCocktails.Clear();
            var cocktails = await mediator.Send(new GetAllCocktailsQuery());
            foreach (var cocktail in cocktails)
                ListOfCocktails.Add(cocktail);
        }

        [RelayCommand]
        private async Task UpdateIngredients()
        {
            ListOfIngredients.Clear();
            if (SelectedCocktail != null)
            {
                var ingredients = await mediator.Send(new GetIngredientsByCocktailIdQuery(SelectedCocktail.Id));
                foreach (var ingredient in ingredients)
                    ListOfIngredients.Add(ingredient);
            }
        }

        [RelayCommand]
        private async Task UpdateSelectedCocktail(Cocktail selected)
        {
            SelectedCocktail = selected;
            await UpdateIngredients();
        }

        [RelayCommand]
        private async Task GoToIngredient(Ingredient selectedIngredient)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "Ingredient", selectedIngredient }
            };
            await Shell.Current.GoToAsync(nameof(IngredientsPage), parameters);
        }

        private async Task GoToAddOrEditPage(string route, IRequest request)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "Request", request }
            };
            await Shell.Current.GoToAsync(route, parameters);
        }

        [RelayCommand]
        private async Task AddIngredient()
        {
            if (SelectedCocktail == null) return;

            await GoToAddOrEditPage(nameof(AddOrEditIngredientPage),
                new AddIngredientCommand { Ingredient = new Ingredient { CocktailId = SelectedCocktail.Id } });

            await UpdateIngredients();
        }

        [RelayCommand]
        private async Task AddCocktail()
        {
            await GoToAddOrEditPage(nameof(AddOrEditCocktailPage), new AddCocktailCommand
            {
                Cocktail = new Cocktail()
            });

            await LoadCocktails();
        }

        [RelayCommand]
        private async Task EditCocktail()
        {
            if (SelectedCocktail == null) return;

            await GoToAddOrEditPage(nameof(AddOrEditCocktailPage),
                new EditCocktailCommand { Cocktail = SelectedCocktail });

            await LoadCocktails();
        }

        [RelayCommand]
        private async Task DeleteCocktail()
        {
            if (SelectedCocktail == null) return;

            await mediator.Send(new DeleteCocktailCommand(SelectedCocktail));
            await LoadCocktails();
        }
    }
}
