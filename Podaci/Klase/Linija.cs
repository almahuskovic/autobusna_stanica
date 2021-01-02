using System;
using System.Collections.Generic;
using System.Text;

namespace Podaci.Klase
{
    public class Linija
    {
        public int LinijaID { get; set; }
        public string OznakaLinije { get; set; }

        public int GPolaskaID { get; set; }
        public Grad GradPolaska { get; set; }

        public int GDolaskaID { get; set; }
        public Grad GradDolaska { get; set; }

        public float CijenaPovratna { get; set; }
        public float CijenaJednosmijerna { get; set; }

    }
}
