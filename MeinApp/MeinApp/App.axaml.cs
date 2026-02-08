using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using MeinApp.DataModel.DBContext;
using MeinApp.ViewModels;
using MeinApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MeinApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    public static IServiceProvider ServiceProvider { get; private set; } 
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            var services = new ServiceCollection();
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<AdminPanelViewModel>();
            services.AddTransient<AddFrageViewModel>();
            services.AddTransient<ShowAllFrageViewModel>();
            services.AddTransient<ShowFrageViewModel>();
            ServiceProvider = services.BuildServiceProvider();
            desktop.MainWindow = new MainWindow
            {
                DataContext =ServiceProvider.GetRequiredService<MainWindowViewModel>()
            };
            using (var db = new AppDbContext())
            {
                db.Database.Migrate(); // oder db.Database.EnsureCreated();
            }
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = App.ServiceProvider.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}