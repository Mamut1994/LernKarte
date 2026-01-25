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
    public partial class ShowFrageViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string? _statusMessage;
        [ObservableProperty]
        private string? _frageText;
        [ObservableProperty]
        private string? _antwortText;
        [ObservableProperty]
        private string _frageID;

    


        [RelayCommand]
        private void Speichern()
        {
            using var dbContext = new DataModel.DBContext.AppDbContext();
            var liste = dbContext.Fragen.FirstOrDefault(x => x.Id == Convert.ToUInt32(FrageID));
            if (liste == null)
            {
                StatusMessage = "Frage nicht gefunden.";
                return;
            }
            if(String.IsNullOrEmpty(FrageID))
            {
                               StatusMessage = "Ungültige Frage ID.";
                return;
            }
           FrageText= liste.FrageText;
              AntwortText= liste.AntwortText;
            StatusMessage = "Frage geladen.";
        }
    }
    }

