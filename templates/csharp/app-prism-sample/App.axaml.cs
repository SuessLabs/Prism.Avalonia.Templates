using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PrismSampleMvvmApp.ViewModels;
using PrismSampleMvvmApp.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation.Regions;
using PrismSampleMvvmApp.Services;

namespace PrismSampleMvvmApp;

public class App : PrismApplication
{
    public App()
    {
        Console.WriteLine("Constructor");
    }

    public override void Initialize()
    {
        Console.WriteLine("Initialize");
        AvaloniaXamlLoader.Load(this);
        
        base.Initialize();
    }

    protected override void OnInitialized()
    {
        var regionManager = Container.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(DashboardView));
        regionManager.RegisterViewWithRegion(RegionNames.SidebarRegion, typeof(SidebarView));
    }
    
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        Console.WriteLine("RegisterTypes()");

        // Services
        containerRegistry.RegisterSingleton<INotificationService, NotificationService>();

        // Views - Generic
        containerRegistry.Register<SidebarView>();
        containerRegistry.Register<MainWindow>();

        // Views - Region Navigation
        containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>();
        containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
        containerRegistry.RegisterForNavigation<SubSettingsView, SubSettingsViewModel>();
    }

    protected override Window CreateShell()
    {
        Console.WriteLine("CreateShell()");
        return Container.Resolve<MainWindow>();
    }
}
