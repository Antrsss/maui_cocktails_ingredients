using Zgirskaya_353502.UI.Pages;

namespace Zgirskaya_353502.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddOrEditCocktailPage), typeof(AddOrEditCocktailPage));
            Routing.RegisterRoute(nameof(AddIngredientPage), typeof(AddIngredientPage));
            Routing.RegisterRoute(nameof(CocktailsPage), typeof(CocktailsPage));
            Routing.RegisterRoute(nameof(IngredientDetailsPage), typeof(IngredientDetailsPage));
        }
    }
}
