using Prism.Commands;
using Prism.Dialogs;

namespace SampleApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IDialogService _dialogService;
    private string _returnedResult = string.Empty;

    public MainWindowViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;

        Title = "Prism.Avalonia Dialog Sample App";
    }

    public string ReturnedResult { get => _returnedResult; set => SetProperty(ref _returnedResult, value); }

    public DelegateCommand CmdShowMessageBox => new(() =>
    {
        // Simple modal dialog represented as a MessageBox
        var title = "MessageBox Title Here";
        var message = "Hello, I am a simple MessageBox modal window with an OK button.\n\n" +
                      "When too much text is added, a scrollbar will appear.";

        _dialogService.ShowDialog(nameof(MessageBoxView), new DialogParameters($"title={title}&message={message}"), r => { });
    });

    public DelegateCommand CmdShowModalDialog => new(() =>
    {
        ;
    });

    public DelegateCommand CmdShowNonModalDialog => new(() =>
    {
        ;
    });
}
