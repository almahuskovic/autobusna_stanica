using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Karta
{
    public class KartaPrikazVM
    {
        public class Row
        {
            public int KartaID { get; set; }
            public DateTime Datum { get; set; }
            public DateTime VaziOd { get; set; }
            public DateTime VaziDo { get; set; }
            public bool IsRezervisana { get; set; }
            public string Sjediste { get; set; }
            public int BrojPutnika { get; set; }
            public string VrstaPopusta { get; set; }
            public string TipKarte { get; set; }
        }
        public List<Row> karte;
    }
}
