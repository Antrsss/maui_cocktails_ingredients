using Microsoft.Extensions.Logging;
using Zgirskaya_353502.Application;
using Zgirskaya_353502.Persistense;
using Zgirskaya_353502.UI.Pages;
using Zgirskaya_353502.UI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Zgirskaya_353502.Persistense.Data;

namespace Zgirskaya_353502.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "Zgirskaya_353502.UI.appsettings.json";

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiCommunityToolkit()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);
        builder.Configuration.AddJsonStream(stream);

        var connStr = builder.Configuration
            .GetConnectionString("SqliteConnection");
        string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
        connStr = String.Format(connStr, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connStr)
            .Options;

        builder.Services
            .AddApplication()
            .AddPersistence(options)
            //.AddPersistence()
            .RegisterPages()
            .RegisterViewModels();

        DbInitializer
            .Initialize(builder.Services.BuildServiceProvider())
            .Wait();



#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}