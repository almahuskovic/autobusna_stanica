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
        public string Datum { get; set; }//viska?
        public string VaziOd { get; set; }//datumpolaska
        public string VaziDo { get; set; }//datumdolaska
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
        public int KreditnaKarticaID { get; set; }
        public KreditnaKartica KreditnaKartica { get; set; }
    }
}
