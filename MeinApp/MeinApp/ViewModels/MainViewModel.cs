using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MeinApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly MainWindowViewModel _main;
    [ObservableProperty]
    private ViewModelBase _currentPage;
    [ObservableProperty]
    private bool _isPaneOpen = true;
    public MainViewModel(MainWindowViewModel m)
    {
        _main = m;
         CurrentPage= App.ServiceProvider.GetRequiredService<AddFrageViewModel>();
    }
    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
    [RelayCommand]
    private void NavigateAddView()
    {
        CurrentPage= App.ServiceProvider.GetRequiredService<AddFrageViewModel>();
    }
    [RelayCommand]
    private void NavigateShow()
    {
        CurrentPage= App.ServiceProvider.GetRequiredService<ShowFrageViewModel>();
    }
    [RelayCommand]
    private void NavigateShowAll()
    {
        CurrentPage= App.ServiceProvider.GetRequiredService<ShowAllFrageViewModel>();
    }
    [RelayCommand]
    private void MainPage()
    {
        _main.CurrentView = App.ServiceProvider.GetRequiredService<AdminPanelViewModel>();
    }
}
