using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeinApp.ViewModels
{
    public partial class MainWindowViewModel:ViewModelBase
    {
        [ObservableProperty]
        private ViewModelBase _currentView;
        public MainWindowViewModel()
        {
           CurrentView=new AdminPanelViewModel(this);
        }
    }
}
