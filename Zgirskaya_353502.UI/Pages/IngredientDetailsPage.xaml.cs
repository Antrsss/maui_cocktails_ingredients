using Zgirskaya_353502.UI.ViewModels;
using Zgirskaya_353502.Domain.Entities;

namespace Zgirskaya_353502.UI.Pages
{
    [QueryProperty(nameof(Ingredient), "ingredient")]
    [QueryProperty(nameof(CocktailId), "cocktailId")]
    public partial class IngredientDetailsPage : ContentPage
    {
        private int _cocktailId;
        public IngredientDetailsPage(IngredientDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        public Ingredient Ingredient { get; set; }
        public int CocktailId
        {
            get => _cocktailId;
            set => _cocktailId = value;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is IngredientDetailsViewModel viewModel)
            {
                viewModel.SetIngredient(Ingredient);
            }
        }
    }
}