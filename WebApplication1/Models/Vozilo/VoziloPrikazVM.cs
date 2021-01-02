﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class VoziloPrikazVM
    {
        public class Row
        {
            public int VoziloID { get; set; }
            public string RegistracijskiBroj { get; set; }
            public int MaxBrojSjedista { get; set; }
            public DateTime DatumZadnjegServisa { get; set; }
        }

        public List<Row> Vozila;
        public string pretraga { get; set; }
    }
}