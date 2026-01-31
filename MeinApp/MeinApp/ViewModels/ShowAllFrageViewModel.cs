using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeinApp.DataModel.DataForm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeinApp.ViewModels
{
    public partial class ShowAllFrageViewModel : ViewModelBase
    {
        public ObservableCollection<FrageStr> FragenListe { get; set; } = new ObservableCollection<FrageStr>();
        public ShowAllFrageViewModel()
        {
            using (var db = new DataModel.DBContext.AppDbContext())
            {
              var alleFragen = db.Fragen.ToList();
                FragenListe.Clear();
                foreach (var frage in alleFragen)
                {
                    FragenListe.Add(frage);
                }
            }
        }
    }


    }

