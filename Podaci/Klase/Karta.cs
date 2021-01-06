using System;
using System.Collections.Generic;
using System.Text;

namespace Podaci.Klase
{
    public class Karta
    {
        public int KartaID { get; set; }
        public DateTime Datum { get; set; }
        public DateTime VaziOd { get; set; }
        public DateTime VaziDo { get; set; }
        public bool IsRezervisana { get; set; }
        public string Sjediste{ get; set; }
        public int BrojPutnika{ get; set; }
        public TipKarte TipKarte { get; set; }
        public int TipKarteID { get; set; }
        public VrstaPopusta VrstaPopusta{ get; set; }
        public int VrstaPopustaID { get; set; }
    }
}
