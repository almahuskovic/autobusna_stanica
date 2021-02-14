using System;
using System.Collections.Generic;
using System.Text;

namespace Podaci.Klase
{
    public class KartaKupac
    {
        public int KartaID { get; set; }
        public string KupacID { get; set; }
        public Karta Karta { get; set; }
        public Kupac Kupac { get; set; }
    }
}
