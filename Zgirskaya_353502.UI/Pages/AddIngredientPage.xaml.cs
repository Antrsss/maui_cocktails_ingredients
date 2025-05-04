namespace Zgirskaya_353502.UI.Pages;

public partial class AddIngredientPage : ContentPage
{
	public AddIngredientPage(ViewModels.AddIngredientViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}