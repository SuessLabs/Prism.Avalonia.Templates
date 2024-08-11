// ---------------------------------------------
//      --- AvaloniaPrismTemplate by Scarementus ---
//      ---        Licence MIT       ---
// ---------------------------------------------

using System;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace PrismSimpleDialogTemplate.ViewModels;

public class NotificationDialogViewModel : ViewModelBase, IDialogAware
{
    private readonly IDialogService _dialog;
    private string _customMessage;

    public NotificationDialogViewModel()
    {
        Title = "Sample Dialog!";
    }

    public DelegateCommand<string> CmdResult => new(s =>
    {
        // None = 0
        // OK = 1
        // Cancel = 2
        // Abort = 3
        // Retry = 4
        // Ignore = 5
        // Yes = 6
        // No = 7
        ButtonResult result = ButtonResult.None;

        if (int.TryParse(s, out int intResult))
            result = (ButtonResult)intResult;

        RaiseRequestClose(new DialogResult(result));
    });

    public event Action<IDialogResult> RequestClose;

    public virtual bool CanCloseDialog()
    {
        return true;
    }

    public virtual void OnDialogClosed()
    {
        // Detatch custom eventhandlers here, etc.
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        CustomMessage = parameters.GetValue<string>("message");
    }

    public string CustomMessage
    {
        get => _customMessage;
        set => SetProperty(ref _customMessage, value);
    }

    public virtual void RaiseRequestClose(IDialogResult dialogResult)
    {
        RequestClose?.Invoke(dialogResult);
    }
}