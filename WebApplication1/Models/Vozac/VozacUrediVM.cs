using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Vozac
{
    public class VozacUrediVM
    {
        public class Row
        {
            public int VozacID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
            public DateTime DatumRodjenja { get; set; }
            [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
            public DateTime DatumZaposlenja { get; set; }
            public string BrojVozacke { get; set; }
        }
        public List<Row> Vozaci;
    }
}
