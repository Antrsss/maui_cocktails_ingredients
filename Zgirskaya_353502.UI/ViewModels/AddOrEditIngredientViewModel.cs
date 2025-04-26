using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zgirskaya_353502.Application.IngredientUseCases.Commands;

namespace Zgirskaya_353502.UI.ViewModels
{
    public partial class AddOrEditIngredientViewModel(IMediator mediator) : ObservableObject, IQueryAttributable
    {
        private IAddOrEditIngredientRequest _request;

        [ObservableProperty] private int _storageOnHand;
        [ObservableProperty] private IngredientData _ingredientData;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _request = query["Request"] as IAddOrEditIngredientRequest;
            if (_request != null)
            {
                _storageOnHand = _request.Ingredient.StorageOnHand;
                _ingredientData = _request.Ingredient.IngredientData;
            }
        }

        [RelayCommand]
        async Task AddOrEditIngredient()
        {
            _request.Ingredient.StorageOnHand = _storageOnHand;
            _request.Ingredient.IngredientData = _ingredientData;
            await mediator.Send(_request);
            await GoBack();
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        void UpdateStorageOnHand(int value)
        {
            _storageOnHand = value;
        }
    }
}
