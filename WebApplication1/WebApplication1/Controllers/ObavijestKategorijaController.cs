using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Podaci;

namespace WebApplication1.Controllers
{
    public class ObavijestKategorijaController : Controller
    {
        MojDbContext db = new MojDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Prikaz(int ObavijestID)
        {
            var m = db.ObavijestKategorija.ToList();
            return View();
        }
    }
}