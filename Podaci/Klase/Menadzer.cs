using System;
using System.Collections.Generic;
using System.Text;

namespace Podaci.Klase
{
    class Menadzer:Korisnik
    {
        public int MenadzerID { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumZaposlenja { get; set; }
    }
}
