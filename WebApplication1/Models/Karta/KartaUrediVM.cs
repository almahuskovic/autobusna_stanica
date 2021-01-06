using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Karta
{
    public class KartaUrediVM
    {
        public int KartaID { get; set; }
        public DateTime Datum { get; set; }
        public DateTime VaziOd { get; set; }
        public DateTime VaziDo { get; set; }
        public bool IsRezervisana { get; set; }
        public bool Aktivna { get; set; }
        public string Sjediste { get; set; }
        public int BrojPutnika { get; set; }
        public List<SelectListItem> VrstaPopusta{ get; set; }
        public int VrstaPopustaID { get; set; }
        public List<SelectListItem> TipKarte{ get; set; }
        public int TipKarteID { get; set; }
    }
}
