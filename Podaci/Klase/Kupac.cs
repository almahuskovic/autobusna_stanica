using System;
using System.Collections.Generic;
using System.Text;

namespace Podaci.Klase
{
    public class Kupac:Korisnik
    {
        public virtual ICollection<KartaKupac> Karta { get; set; }
    }
}
