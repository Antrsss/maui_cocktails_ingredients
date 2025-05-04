using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Zgirskaya_353502.Application.CocktailUseCases.Commands;

public partial class AddOrEditCocktailViewModel(IMediator mediator) : ObservableObject, IQueryAttributable
{
    private IAddOrEditCocktailRequest _request;
    private int _cocktailId;

    [ObservableProperty] private string _name;
    [ObservableProperty] private double _preparationTime;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _request = query["Request"] as IAddOrEditCocktailRequest;
        if (_request == null) return;

        _cocktailId = _request.Cocktail.Id;
        _name = _request.Cocktail.Name;
        _preparationTime = _request.Cocktail.PreparationTime;
    }

    [RelayCommand]
    async Task AddOrEditCocktail()
    {
        try
        {
            // Создаем новый объект для обновления
            var updatedCocktail = new Cocktail
            {
                Id = _cocktailId,
                Name = _name,
                PreparationTime = _preparationTime
            };

            // Обновляем данные в запросе
            _request.Cocktail = updatedCocktail;

            await mediator.Send(_request);
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}