namespace Zgirskaya_353502.UI.Pages;

public partial class IngredientsPage : ContentPage
{
	public IngredientsPage(ViewModels.IngredientsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}