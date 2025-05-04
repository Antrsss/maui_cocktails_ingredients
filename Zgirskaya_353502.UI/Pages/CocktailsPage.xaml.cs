using Zgirskaya_353502.UI.ViewModels;

namespace Zgirskaya_353502.UI.Pages;

public partial class CocktailsPage : ContentPage
{
	public CocktailsPage(CocktailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CocktailsViewModel viewModel)
        {
            await viewModel.OnAppearing();
        }
    }
}