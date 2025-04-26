using Zgirskaya_353502.UI.Pages;

namespace Zgirskaya_353502.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddOrEditCocktailPage), typeof(AddOrEditCocktailPage));
            Routing.RegisterRoute(nameof(AddOrEditIngredientPage), typeof(AddOrEditIngredientPage));
            Routing.RegisterRoute(nameof(CocktailsPage), typeof(CocktailsPage));
            Routing.RegisterRoute(nameof(IngredientsPage), typeof(IngredientsPage));
        }
    }
}
