// ---------------------------------------------
//      --- AvaloniaPrismTemplate by Scarementus ---
//      ---        Licence MIT       ---
// ---------------------------------------------

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PrismSimpleDialogTemplate.Views;

public partial class NotificationDialogView : UserControl
{
    public NotificationDialogView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}