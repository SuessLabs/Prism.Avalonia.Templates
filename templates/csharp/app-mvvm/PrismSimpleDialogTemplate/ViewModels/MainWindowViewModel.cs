// ---------------------------------------------
//      --- AvaloniaPrismTemplate by Scarementus ---
//      ---        Licence MIT       ---
// ---------------------------------------------

using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace PrismSimpleDialogTemplate.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IDialogService _dialogService;
    private string _returnedResult;

    public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
    {
        _dialogService = dialogService;

        Title = "My Dialog";
    }

    public DelegateCommand CmdShowDialog => new(() =>
    {
        var message = "This is a message that should be shown in the dialog";

        _dialogService.ShowDialog("NotificationDialogView", new DialogParameters($"message={message}"), r =>
        {
            if (r is null)
            {
                Title = "Try Again";
                ReturnedResult = "Null Result Returned";
            }
            
            ReturnedResult = r.Result.ToString();

            Title = r.Result switch
            {
                ButtonResult.None => "Result is None",
                ButtonResult.OK => "Result is OK",
                ButtonResult.Cancel => "Result is Cancel",
                _ => "I Don't know what you did!?"
            };
        });
    });
    
    public DelegateCommand CmdShowRegular => new DelegateCommand(() =>
    {
        _dialogService.Show("NotificationDialogView", r =>
        {
            if (r is null)
            {
                Title = "Try again";
                ReturnedResult = "Null result returned";
            }

            ReturnedResult = r.Result.ToString();

            // Same as if-statements, just a switch-expression.
            Title = r.Result switch
            {
                ButtonResult.None => "Result is None",
                ButtonResult.OK => "Result is OK",
                ButtonResult.Cancel => "Result is Cancel",
                _ => "I Don't know what you did!?",
            };
        });
    });
    
    public string ReturnedResult
    {
        get => _returnedResult;
        set => SetProperty(ref _returnedResult, value);
    }
}