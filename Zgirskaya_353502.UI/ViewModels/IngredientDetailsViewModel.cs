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
        private Ingredient _ingredient = null!;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private int _storageOnHand;

        [ObservableProperty]
        private decimal _price; // Изменили decimal на double

        public IngredientDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void SetIngredient(Ingredient ingredient)
        {
            _ingredient = ingredient;
            Name = ingredient.IngredientData.Name;
            StorageOnHand = ingredient.StorageOnHand;
            Price = ingredient.IngredientData.Price; // Явное преобразование decimal в double
        }

        [RelayCommand]
        private async Task Save()
        {
            // Создаем новый объект IngredientData с обновленными значениями
            var updatedData = new IngredientData(
                _ingredient.IngredientData.Name,
                (decimal)Price) // Явное преобразование double в decimal
            {
                // Если есть другие свойства, которые нужно сохранить
                // OtherProperty = _ingredient.IngredientData.OtherProperty
            };

            var updatedIngredient = new Ingredient(
                updatedData,
                StorageOnHand)
            {
                Id = _ingredient.Id,
                CocktailId = _ingredient.CocktailId
            };

            await _mediator.Send(new EditIngredientCommand
            {
                Ingredient = updatedIngredient
            });

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task Delete()
        {
            await _mediator.Send(new DeleteIngredientCommand(_ingredient));
            await Shell.Current.GoToAsync("..");
        }
    }
}