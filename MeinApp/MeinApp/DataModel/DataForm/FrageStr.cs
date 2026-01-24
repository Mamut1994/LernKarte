using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeinApp.DataModel.DataForm
{
    public class FrageStr
    {
        [Key]
        public int Id { get; set; }
        public string FrageText { get; set; } = string.Empty;
        public string AntwortText { get; set; } = string.Empty;
        public FrageArt ArtDerFrage { get; set; }


    }
   public  enum FrageArt
    {
        unknown = 0,
        Programmier,
        Datenbank,
        Netzwerk,
        USV,

        ProjektManagement,
        ITSicherheit,

    }
}
