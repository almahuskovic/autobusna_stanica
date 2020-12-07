using Microsoft.AspNetCore.Mvc;
using Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class DrzavaController : Controller
    {
         MojDbContext db = new MojDbContext();
       

        public IActionResult Prikaz()
        {
            var d = db.Drzava.ToList();
            //List<Drzava> drzave = db.Drzava.ToList();

            //ViewData["drzave"] = drzave;
            return View(d);
        }
    }
}


