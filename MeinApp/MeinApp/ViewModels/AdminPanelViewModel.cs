using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeinApp.ViewModels
{
    public partial class AdminPanelViewModel:ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase _currentView;

        [RelayCommand]
        private void Setting()
        {
            CurrentView =new MainViewModel() ;
        }
    }
}
