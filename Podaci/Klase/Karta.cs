using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Podaci.Klase
{
    public class Karta
    {
        [Key]
        public int KartaID { get; set; }
        public DateTime Datum { get; set; }
        public string VaziOd { get; set; }
        public string VaziDo { get; set; }
        public bool IsRezervisana { get; set; }
        public int BrojPutnika{ get; set; }
        public TipKarte TipKarte { get; set; }
        public int TipKarteID { get; set; }
        public VrstaPopusta VrstaPopusta{ get; set; }
        public int VrstaPopustaID { get; set; }
        public Stajalista Polaziste{ get; set; }
        public int PolazisteID { get; set; }
        public Stajalista Dolaziste { get; set; }
        public int DolazisteID { get; set; }
    }
}
