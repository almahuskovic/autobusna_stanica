using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podaci.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Karta
{
    public class KartaUrediVM
    {
        public int KartaID { get; set; }
        public string VrijemePolaska { get; set; }
        public string VrijemeDolaska { get; set; }
        public string Satnica { get; set; }
        public string Stajalista { get; set; }
        public string PolazisteNaziv { get; set; }
        public string DolazisteNaziv { get; set; }
        public string ImeLinije { get; set; }
        public string Cijena { get; set; }
        public int SlobodnihMjesta { get; set; }
        public string DatumPolaska { get; set; }
        public string DatumDolaska { get; set; }
        public List<SelectListItem> TipKarte { get; set; }
        public int TipKarteID { get; set; }
        public List<SelectListItem> Polaziste { get; set; }
        public int PolazisteID { get; set; }
        public List<SelectListItem> Dolaziste { get; set; }
        public int DolazisteID { get; set; }
        public int LinijaId{ get; set; }
        public int RedniBrojPolazista{ get; set; }
        public int RedniBrojDolazista{ get; set; }
    }
}
