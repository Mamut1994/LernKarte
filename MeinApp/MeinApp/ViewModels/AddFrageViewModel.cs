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
    public partial class AddFrageViewModel: ViewModelBase
    {
        [ObservableProperty]
        private string? _statusMessage;
        [ObservableProperty]
        private string? _frageText;
        [ObservableProperty]
        private string? _antwortText;
        [ObservableProperty]
        private FrageArt _artDerFrage=FrageArt.unknown;

        public ObservableCollection<FrageArt> FrageArten { get; }
            = new ObservableCollection<FrageArt>(Enum.GetValues(typeof(FrageArt)).Cast<FrageArt>());


        [RelayCommand]
        private void Speichern()
        {
            using var dbContext = new DataModel.DBContext.AppDbContext();

            if(String.IsNullOrEmpty(FrageText) || String.IsNullOrEmpty(AntwortText))
            {
                StatusMessage="Bitte Frage und Antwort eingeben.";
                return;
            }
            if(ArtDerFrage==FrageArt.unknown)
            {
                StatusMessage="Bitte Art der Frage auswählen.";
                return;
            }
            var neueFrage = new FrageStr
            {
                FrageText = FrageText!,
                AntwortText = AntwortText!,
                ArtDerFrage = ArtDerFrage
            };
            dbContext.Fragen.Add(neueFrage);
            dbContext.SaveChanges();
        }
    }
}
