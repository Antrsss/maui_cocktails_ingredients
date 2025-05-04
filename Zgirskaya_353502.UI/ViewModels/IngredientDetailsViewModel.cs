using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Zgirskaya_353502.Application.IngredientUseCases.Commands;
using Zgirskaya_353502.Domain.Entities;
using MediatR;

namespace Zgirskaya_353502.UI.ViewModels
{
    public partial class IngredientDetailsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        [ObservableProperty]
        private Ingredient _ingredient;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private int _storageOnHand;

        [ObservableProperty]
        private decimal _price;

        public IngredientDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void SetIngredient(Ingredient ingredient)
        {
            _ingredient = ingredient;
            Name = ingredient.IngredientData.Name;
            StorageOnHand = ingredient.StorageOnHand;
            Price = ingredient.IngredientData.Price;

            OnPropertyChanged(nameof(StorageOnHand));
            OnPropertyChanged(nameof(Price));
        }

        [RelayCommand]
        private async Task Save()
        {
            try
            {
                // Обновляем ингредиент
                _ingredient.IngredientData = new IngredientData(
                    _ingredient.IngredientData.Name,
                    Price);
                _ingredient.StorageOnHand = StorageOnHand;

                await _mediator.Send(new EditIngredientCommand
                {
                    Ingredient = _ingredient
                });

                // Возвращаемся назад с флагом обновления
                await Shell.Current.GoToAsync("..?refresh=true");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to save: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task Delete()
        {
            await _mediator.Send(new DeleteIngredientCommand(_ingredient));
            await Shell.Current.GoToAsync("..");
        }
    }
}