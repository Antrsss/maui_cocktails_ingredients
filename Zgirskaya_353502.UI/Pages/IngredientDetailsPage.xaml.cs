using Zgirskaya_353502.UI.ViewModels;
using Zgirskaya_353502.Domain.Entities;

namespace Zgirskaya_353502.UI.Pages
{
    [QueryProperty(nameof(Ingredient), "ingredient")]
    public partial class IngredientDetailsPage : ContentPage
    {
        private Ingredient _ingredient;

        public Ingredient Ingredient
        {
            get => _ingredient;
            set
            {
                _ingredient = value;
                if (BindingContext is IngredientDetailsViewModel viewModel && value != null)
                {
                    viewModel.SetIngredient(value);
                }
            }
        }

        public IngredientDetailsPage(IngredientDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}