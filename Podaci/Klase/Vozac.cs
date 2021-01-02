﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Podaci.Klase
{
    public class Vozac
    {
        [Key]
        public int VozacID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja{ get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string BrojVozacke { get; set; }
    }
}
