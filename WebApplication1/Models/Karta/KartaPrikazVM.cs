using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Karta
{
    public class KartaPrikazVM
    {
        public int KartaID { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumDolaska { get; set; }
        public List<SelectListItem> TipKarte { get; set; }
        public int TipKarteID { get; set; }
        public List<SelectListItem> Polaziste { get; set; }
        public int PolazisteID { get; set; }
        public List<SelectListItem> Dolaziste { get; set; }
        public int DolazisteID { get; set; }
    }
}
