using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeinApp.DataModel.DataForm
{
    public class PrFragen
    {
        [Key]
        
            public int Id { get; set; }

            public int Jahr { get; set; }          // z.B. 2024
            public PrFrageArt Art { get; set; }        // AP1, AP2, WISO, GA1, GA2

            public string FrageText { get; set; }
            public string AntwortText { get; set; }
        public bool IsBadenWuerttemberg { get; set; } // Ja/Nein
        public Saison Saison { get; set; } // Sommer oder Winter
        public byte[] AntwortBild { get; set; }

            public DateTime ErstelltAm { get; set; } = DateTime.Now;
        }
        public enum PrFrageArt
        {
            AP1,
            AP2,
            WISO
        }
    public enum  Saison
    {
        Sommer,
        Winter
    }
    
}

