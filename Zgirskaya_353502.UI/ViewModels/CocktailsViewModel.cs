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
        private readonly IMediator _mediator = mediator;

        [ObservableProperty]
        private Cocktail? _selectedCocktail;

        public ObservableCollection<Cocktail> ListOfCocktails { get; } = new();
        public ObservableCollection<Ingredient> ListOfIngredients { get; } = new();

        [RelayCommand]
        public async Task OnAppearing()
        {
            await LoadCocktails();

            if (ListOfCocktails.Any())
            {
                SelectedCocktail = ListOfCocktails.First();
                await LoadIngredientsForSelectedCocktail();
            }
        }

        [RelayCommand]
        private async Task LoadCocktails()
        {
            ListOfCocktails.Clear();
            var cocktails = await _mediator.Send(new GetAllCocktailsQuery());
            foreach (var cocktail in cocktails)
                ListOfCocktails.Add(cocktail);
        }

        [RelayCommand]
        private async Task UpdateSelectedCocktail(Cocktail selected)
        {
            if (selected != null)
            {
                SelectedCocktail = selected;
                await LoadIngredientsForSelectedCocktail();
            }
        }

        partial void OnSelectedCocktailChanged(Cocktail? value)
        {
            if (value != null)
            {
                _ = LoadIngredientsForSelectedCocktail();
            }
        }

        [RelayCommand]
        private async Task LoadIngredientsForSelectedCocktail()
        {
            ListOfIngredients.Clear();

            if (SelectedCocktail != null)
            {
                var ingredients = await _mediator.Send(
                    new GetIngredientsByCocktailIdQuery(SelectedCocktail.Id));

                foreach (var ingredient in ingredients)
                {
                    ListOfIngredients.Add(ingredient);
                }
            }
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
        private async Task AddCocktail()
        {
            await GoToAddOrEditPage(nameof(AddOrEditCocktailPage), new AddCocktailCommand
            {
                Cocktail = new Cocktail()
            });
        }

        [RelayCommand]
        private async Task EditCocktail()
        {
            try
            {
                if (SelectedCocktail == null)
                {
                    await Shell.Current.DisplayAlert("Error", "No cocktail selected", "OK");
                    return;
                }

                Console.WriteLine($"Editing cocktail: {SelectedCocktail.Id}, {SelectedCocktail.Name}");

                var command = new EditCocktailCommand
                {
                    Cocktail = new Cocktail
                    {
                        Id = SelectedCocktail.Id,
                        Name = SelectedCocktail.Name,
                        PreparationTime = SelectedCocktail.PreparationTime
                    }
                };

                await GoToAddOrEditPage(nameof(AddOrEditCocktailPage), command);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Debug", ex.ToString(), "OK");
            }
        }

        [RelayCommand]
        private async Task DeleteCocktail()
        {
            if (SelectedCocktail == null) return;

            await mediator.Send(new DeleteCocktailCommand(SelectedCocktail));
            await LoadCocktails();
        }

        [RelayCommand]
        private async Task OpenIngredientDetails(Ingredient ingredient)
        {
            if (ingredient == null) return;

            var parameters = new Dictionary<string, object>
            {
                { "ingredient", ingredient }
            };

            await Shell.Current.GoToAsync(nameof(IngredientDetailsPage), parameters);
        }

        [RelayCommand]
        private async Task AddIngredient()
        {
            if (SelectedCocktail == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Сначала выберите коктейль", "OK");
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(AddIngredientPage)}?cocktailId={SelectedCocktail.Id}");
        }
    }
}