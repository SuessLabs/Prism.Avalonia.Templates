using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PrismSimpleDialogTemplate.ViewModels;
using PrismSimpleDialogTemplate.Views;
using Prism.DryIoc;
using Prism.Ioc;

namespace PrismSimpleDialogTemplate;

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
        // Called after initialize
    }
    
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        Console.WriteLine("Register Types");
        containerRegistry.Register<MainWindow>();
        containerRegistry.RegisterDialog<NotificationDialogView, NotificationDialogViewModel>();
    }

    protected override Window CreateShell()
    {
        Console.WriteLine("CreateShell()");
        return Container.Resolve<MainWindow>();
    }
}