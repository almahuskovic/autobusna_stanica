using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Podaci.Klase
{
    public class TipUposlenika
    {
        [Key]
        public int TipUposlenikaID { get; set; }
        public string Naziv { get; set; }
    }
}
