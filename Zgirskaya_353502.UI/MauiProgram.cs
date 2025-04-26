using Microsoft.Extensions.Logging;
using Zgirskaya_353502.Application;
using Zgirskaya_353502.Persistense;
using Zgirskaya_353502.UI.Pages;
using Zgirskaya_353502.UI.ViewModels;
using CommunityToolkit.Maui;

namespace Zgirskaya_353502.UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiCommunityToolkit()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services
			.AddApplication()
			.AddPersistence();

        builder.Services.AddTransient<CocktailsPage>();
        builder.Services.AddTransient<CocktailsViewModel>();
        builder.Services.AddTransient<AddOrEditCocktailPage>();
        builder.Services.AddTransient<AddOrEditCocktailViewModel>();
        builder.Services.AddTransient<IngredientsPage>();
        builder.Services.AddTransient<IngredientsViewModel>();
        builder.Services.AddTransient<AddOrEditIngredientPage>();
        builder.Services.AddTransient<AddOrEditIngredientViewModel>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
