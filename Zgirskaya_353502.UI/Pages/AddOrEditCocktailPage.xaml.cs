using Zgirskaya_353502.UI.ViewModels;

namespace Zgirskaya_353502.UI.Pages;

public partial class AddOrEditCocktailPage : ContentPage
{
	public AddOrEditCocktailPage(AddOrEditCocktailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}