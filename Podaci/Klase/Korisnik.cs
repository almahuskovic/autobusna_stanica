using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Podaci.Klase
{
    public class Korisnik:IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime{ get; set; }
    }
}
