using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Karta
{
    public class KreditnaKarticaPrikazVM
    {
        public class KarticaRedovi
        {
            public int KreditnaKarticaID { get; set; }
            public string BrojKartice { get; set; }
            public string ImeVlasnika { get; set; }
            public int VerKod { get; set; }
            public string DatumIsteka { get; set; }
        }
        public List<KarticaRedovi> KarticeKupca { get; set; }
        public List<SelectListItem> Kartice{ get; set; }
        public int KarticeID{ get; set; }
        public string BrojKarticeNova { get; set; }
        public string ImeVlasnikaNova { get; set; }
        public int VerKodNova { get; set; }
        public string DatumIstekaNova { get; set; }
    }
}
