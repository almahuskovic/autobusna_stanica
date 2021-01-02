using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class LinijaUrediVM
    {
        public int LinijaID { get; set; }
        public string OznakaLinije { get; set; }

        public int GPolaskaID { get; set; }
        public int GDolaskaID { get; set; }

        public float CijenaPovratna { get; set; }
        public float CijenaJednosmijerna { get; set; }

        public List<SelectListItem> Gradovi;
    }
}
