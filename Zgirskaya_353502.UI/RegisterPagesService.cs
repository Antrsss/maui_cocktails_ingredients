using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zgirskaya_353502.UI.Pages;
using Zgirskaya_353502.UI.ViewModels;

namespace Zgirskaya_353502.UI
{
    public static class RegisterPagesService
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {

            services.AddSingleton<CocktailsPage>();
            services.AddTransient<AddOrEditCocktailPage>();
            services.AddTransient<IngredientDetailsPage>();
            services.AddTransient<AddIngredientPage>();

            return services;
        }
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<CocktailsViewModel>();
            services.AddTransient<AddOrEditCocktailViewModel>();
            services.AddTransient<IngredientDetailsViewModel>();
            services.AddTransient<AddIngredientViewModel>();

            return services;
        }
    }
}
