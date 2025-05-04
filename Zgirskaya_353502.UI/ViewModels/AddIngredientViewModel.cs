using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Zgirskaya_353502.Application.IngredientUseCases.Commands;
using Zgirskaya_353502.Domain.Entities;

namespace Zgirskaya_353502.UI.ViewModels
{
    [QueryProperty(nameof(CocktailId), "cocktailId")]
    public partial class AddIngredientViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        [ObservableProperty]
        private string _cocktailId;

        [ObservableProperty]
        private string _ingredientName;

        [ObservableProperty]
        private int _storageOnHand;

        [ObservableProperty]
        private decimal _price;

        public AddIngredientViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [RelayCommand]
        private async Task Save()
        {
            if (string.IsNullOrWhiteSpace(IngredientName))
            {
                await Shell.Current.DisplayAlert("Ошибка", "Введите название ингредиента", "OK");
                return;
            }

            var ingredient = new Ingredient
            {
                IngredientData = new IngredientData(IngredientName, Price), // Используем конструктор
                StorageOnHand = StorageOnHand,
                CocktailId = int.Parse(CocktailId)
            };

            await _mediator.Send(new AddIngredientCommand
            {
                Ingredient = ingredient
            });
            await Shell.Current.GoToAsync(".."); // Возвращаемся назад
        }
    }
}