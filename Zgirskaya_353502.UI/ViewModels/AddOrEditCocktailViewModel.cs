using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zgirskaya_353502.Application.CocktailUseCases.Commands;

namespace Zgirskaya_353502.UI.ViewModels
{
    public partial class AddOrEditCocktailViewModel(IMediator mediator) : ObservableObject, IQueryAttributable
    {
        private IAddOrEditCocktailRequest _request;

        [ObservableProperty] private string _name;
        [ObservableProperty] private double _preparationTime;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _request = query["Request"] as IAddOrEditCocktailRequest;
            if (_request == null) return;
            _name = _request.Cocktail.Name;
            _preparationTime = _request.Cocktail.PreparationTime;
        }

        [RelayCommand]
        async Task AddOrEditCocktail()
        {
            _request.Cocktail.Name = _name;
            _request.Cocktail.PreparationTime = _preparationTime;
            await mediator.Send(_request);
            await GoBack();
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
