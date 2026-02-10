using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeinApp.DataModel.DataForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeinApp.ViewModels
{
    public partial class RandomTestViewModel : ViewModelBase
    {

        public ObservableCollection<FrageArt> FrageArten { get; } =
            new(Enum.GetValues<FrageArt>().Where(a => a != FrageArt.unknown));

        [ObservableProperty]
        private FrageArt? _aktuellesThema;
      
    
    }
}

