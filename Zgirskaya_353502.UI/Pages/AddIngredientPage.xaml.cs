using Zgirskaya_353502.UI.ViewModels;

namespace Zgirskaya_353502.UI.Pages;

public partial class AddIngredientPage : ContentPage
{
	public AddIngredientPage(AddIngredientViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}