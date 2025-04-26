namespace Zgirskaya_353502.UI.Pages;

public partial class AddOrEditCocktailPage : ContentPage
{
	public AddOrEditCocktailPage(ViewModels.AddOrEditCocktailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}