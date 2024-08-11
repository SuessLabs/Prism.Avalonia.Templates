using Prism.Mvvm;
using Prism.Regions;

namespace PrismSimpleDialogTemplate.ViewModels;

public class ViewModelBase : BindableBase, INavigationAware
{
    private string _title;

    public string Title { get => _title; set => SetProperty(ref _title, value); }
        
    public void OnNavigatedTo(NavigationContext navigationContext)
    {
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        // Auto-allow navigation
        return OnNavigatingTo(navigationContext);
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public virtual bool OnNavigatingTo(NavigationContext navigationContext)
    {
        return true;
    }
}