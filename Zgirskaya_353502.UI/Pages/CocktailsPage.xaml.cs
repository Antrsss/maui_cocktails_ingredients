namespace Zgirskaya_353502.UI.Pages;

public partial class CocktailsPage : ContentPage
{
	public CocktailsPage(ViewModels.CocktailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ViewModels.CocktailsViewModel viewModel)
        {
            await viewModel.OnAppearing();
        }
    }
}