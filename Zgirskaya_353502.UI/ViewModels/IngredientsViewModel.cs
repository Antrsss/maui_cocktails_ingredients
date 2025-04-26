using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Zgirskaya_353502.Application.IngredientUseCases.Commands;
using Zgirskaya_353502.Application.IngredientUseCases.Queries;
using Zgirskaya_353502.UI.Pages;

namespace Zgirskaya_353502.UI.ViewModels
{
    [QueryProperty("Ingredient", "Ingredient")]
    public partial class IngredientsViewModel(IMediator mediator) : ObservableObject
    {
        [ObservableProperty] private Ingredient _ingredient;

        [ObservableProperty] private int _storageOnHand;
        [ObservableProperty] private IngredientData _ingredientData;

        [RelayCommand]
        async Task GetIngredientById()
        {
            _ingredient = await mediator.Send(new GetIngredientByIdQuery(_ingredient.Id));
            _storageOnHand = _ingredient.StorageOnHand;
            _ingredientData = _ingredient.IngredientData;
        }

        [RelayCommand]
        async Task DeleteIngredient()
        {
            await mediator.Send(new DeleteIngredientCommand(_ingredient));
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task EditIngredient()
        {
            await GoToAddOrEditPage(nameof(AddOrEditIngredientPage),
                new EditIngredientCommand { Ingredient = _ingredient });
        }

        private async Task GoToAddOrEditPage(string route, IRequest request)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Request", request },
                { "Ingredient", _ingredient }
            };
            await Shell.Current.GoToAsync(route, parameters);
        }
    }
}
