using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Prism.Ioc;
using PrismSampleMvvmApp.Services;

namespace PrismSampleMvvmApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        
        var notifyService = ContainerLocator.Current.Resolve<INotificationService>();
        notifyService.SetHostWindow(this);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}