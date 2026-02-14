using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeinApp.DataModel.DataForm;
using MeinApp.DataModel.DBContext;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class AlleThemenViewModel : ViewModelBase
    {
        private readonly MainWindowViewModel _main;
        public ObservableCollection<FrageArt> FrageArten { get; } =
            new(Enum.GetValues<FrageArt>().Where(a => a != FrageArt.unknown));
       
       private  AppDbContext _dbContext=new AppDbContext();
       

        [ObservableProperty]
        private FrageArt _aktuellesThema ;
        [ObservableProperty]
        private string? _frageText;
        [ObservableProperty]
        private string? _antwortText;

        // Neue Felder für aktuelle Fragenliste und Index
        private List<FrageStr> _aktuelleFragen = new();
        private int _aktuellerIndex;
      
        public AlleThemenViewModel(MainWindowViewModel main)
        {
            _main = main;
        }
        partial void OnAktuellesThemaChanged(FrageArt value)
        {
         
               
               
                _aktuelleFragen.Clear();
                _aktuelleFragen = ListeLaden(AktuellesThema);
            FrageText = "";
            AntwortText = "";
            if (_aktuelleFragen.Any())
            {
                _aktuellerIndex = 0;
                    FrageText = _aktuelleFragen[_aktuellerIndex].FrageText;
            }
            else
            {
                FrageText = "noch keine Fragen hinzügefugt";
                AntwortText = "";
            }
            

           
        }
    private List<FrageStr> ListeLaden(FrageArt A)
        {

            //if (AktuellesThema == FrageArt.unknown)
            //    return null;
            if(A==FrageArt.Netzwerk)
            {
                return _dbContext.Fragen.Where(f => f.ArtDerFrage == FrageArt.Netzwerk).ToList();
            }
            else if(A==FrageArt.ITSicherheit)
            {
                return _dbContext.Fragen.Where(f=>f.ArtDerFrage==FrageArt.ITSicherheit).ToList();
            }
            else if (A == FrageArt.Datenbank)
            {
                return _dbContext.Fragen.Where(f => f.ArtDerFrage == FrageArt.Datenbank).ToList();
            }
            else if (A == FrageArt.ITSystemInfrastruktur)
            {
                return _dbContext.Fragen.Where(f => f.ArtDerFrage == FrageArt.ITSystemInfrastruktur).ToList();
            }
            else if (A== FrageArt.BWL)
            {
                return _dbContext.Fragen.Where(f => f.ArtDerFrage == FrageArt.BWL).ToList();
            }
            else if (A == FrageArt.Kundenorientierung)
            {
                return _dbContext.Fragen.Where(f => f.ArtDerFrage == FrageArt.Kundenorientierung).ToList();
            }
            else if (A == FrageArt.WISO)
            {
                return _dbContext.Fragen.Where(f => f.ArtDerFrage == FrageArt.WISO).ToList();
            }
            else
            {
                return _dbContext.Fragen.Where(x=>x.ArtDerFrage==FrageArt.Programmier).ToList();
            }
        }

        private void AntwortZeigen(List<FrageStr>ll)
        {
            if (_aktuelleFragen.Any())
                AntwortText = ll[_aktuellerIndex].AntwortText;
            else
                AntwortText = "";
        }

        // Parameterlose Command-Methode
        [RelayCommand]
        private void AntwortZeigen()
        {
            AntwortZeigen(_aktuelleFragen);
        }

        // Optional: Methode zum Wechseln zur nächsten Frage
        [RelayCommand]
        private void NaechsteFrage()
        {
            if(_aktuelleFragen.Any())
            {
                AntwortText = "";
        if(_aktuellerIndex==0)
            {
                    FrageText = _aktuelleFragen[_aktuellerIndex].FrageText;
                    if (_aktuelleFragen.Count==1)
                    {
                        _aktuellerIndex = 0;
                        return;
                    }
                _aktuellerIndex++;
                
            }
        else if(_aktuellerIndex==_aktuelleFragen.Count-1)
            {
                FrageText = _aktuelleFragen[_aktuellerIndex].FrageText;
                    _aktuellerIndex = 0;
                    
            }
            else
            {
                _aktuellerIndex++;
                FrageText = _aktuelleFragen[_aktuellerIndex].FrageText;
            }

            }
            else
            {
                FrageText = "erledigt";
            }
            
            
        }
        [RelayCommand]
        private void GoAdminPage()
        { 
        _main.CurrentView = App.ServiceProvider.GetRequiredService<AdminPanelViewModel>();
        }
    }
}

