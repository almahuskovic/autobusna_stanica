using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Karta
{
    public class KartaKupovinaVM
    {
        public float Cijena { get; set; }
        public float CijenaBezPopusta { get; set; }
        public string DatumPolaska { get; set; }
        public string DatumDolaska { get; set; }
        public string LinijaPolaziste { get; set; }
        public string LinijaDolaziste { get; set; }
        public string OznakaLinije { get; set; }
        public int Dijete { get; set; }
        public int Odrasli { get; set; }
        public int Student { get; set; }
        public int Penzioner { get; set; }

        public string PolazisteNaziv { get; set; }
        public string DolazisteNaziv { get; set; }
        public string TipKarte { get; set; }
        public int PolazisteID { get; set; }
        public int DolazisteID { get; set; }
        public int TipKarteID { get; set; }
        //kartica
        public class KarticaRedovi
        {
            public int KreditnaKarticaID { get; set; }
            public string BrojKartice { get; set; }
            public string ImeVlasnika { get; set; }
            public int VerKod { get; set; }
            public string DatumIsteka { get; set; }
        }
        public List<KarticaRedovi> KarticeKupca { get; set; }
        public List<SelectListItem> Kartice { get; set; }
        public int KarticeID { get; set; }
        public string BrojKarticeNova { get; set; }
        public string ImeVlasnikaNova { get; set; }
        public int VerKodNova { get; set; }
        public string DatumIstekaNova { get; set; }
        public bool SpasiKarticu { get; set; }
    }
}
