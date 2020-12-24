using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class VoziloUrediVM
    {
        public int VoziloID { get; set; }
        public string RegistracijskiBroj { get; set; }
        public int MaxBrojSjedista { get; set; }
        [BindProperty, DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DatumZadnjegServisa { get; set; }
    }
}
