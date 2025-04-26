namespace Zgirskaya_353502.UI.Pages;

public partial class AddOrEditIngredientPage : ContentPage
{
	public AddOrEditIngredientPage(ViewModels.AddOrEditIngredientViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}