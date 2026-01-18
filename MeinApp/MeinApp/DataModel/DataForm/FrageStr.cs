using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeinApp.DataModel.DataForm
{
    public class FrageStr
    {
        public string FrageText { get; set; } = string.Empty;
        public string AntwortText { get; set; } = string.Empty;
        public FrageArt ArtDerFrage { get; set; }


    }
}
