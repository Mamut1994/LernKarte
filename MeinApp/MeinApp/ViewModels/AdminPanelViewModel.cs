using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeinApp.ViewModels
{
    public partial class AdminPanelViewModel:ViewModelBase
    {
        private readonly MainWindowViewModel _main; 
        public AdminPanelViewModel(MainWindowViewModel main)
        {
            _main = main;
        }

        [RelayCommand]
        private void Setting()
        {
          _main.CurrentView = App.ServiceProvider.GetRequiredService<MainViewModel>();
        }
    }
}

