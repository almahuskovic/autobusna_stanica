using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Obavijest
{
    public class ObavijestDodajVM
    {
        public int ObavijestID { get; set; }
        public string Naslov { get; set; }
        public string Podnaslov { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
        public string ObavijestKategorija { get; set; }
        public DateTime DatumObjave { get; set; }  
        public List<SelectListItem> Kategorije { get; set; }
        public int KategorijaID { get; set; }
    }
}
