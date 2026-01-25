using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MeinApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage;
    [ObservableProperty]
    private bool _isPaneOpen = true;

    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
    [RelayCommand]
    private void NavigateAddView()
    {
        CurrentPage= new AddFrageViewModel();
    }
    [RelayCommand]
    private void NavigateShow()
    {
        CurrentPage= new ShowFrageViewModel();
    }
}
