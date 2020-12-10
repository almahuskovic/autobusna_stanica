using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Podaci;
using WebApplication1.Models;
using WebApplication1.Models.ObavijestKategorija;

namespace WebApplication1.Controllers
{
    public class ObavijestKategorijaController : Controller
    {
        MojDbContext db = new MojDbContext();
        public IActionResult Prikaz()
        {
            var m = db.ObavijestKategorija.
                Select(ob => new ObavijestKategorijaPrikazVM
                {
                    ObavijestID = ob.ObavijestID,
                    Naziv = ob.Naziv
                })
                .ToList();
            return View(m);
        }
        public IActionResult Uredi(int ObavijestID)
        {
            ObavijestKategorijaUrediVM m;
            if (ObavijestID == 0)
            {
                m = new ObavijestKategorijaUrediVM();
            }
            else
            {
                m = db.ObavijestKategorija.Where(o => o.ObavijestID == ObavijestID)
               .Select(ob => new ObavijestKategorijaUrediVM
               {
                   Naziv = ob.Naziv
               }).Single();
            }

            return View(m);
        }
        public IActionResult Snimi(ObavijestKategorijaUrediVM x)
        {
            ObavijestKategorija m;
            if (x.ObavijestID == 0)
            {
                m = new ObavijestKategorija();
                db.Add(m);
            }
            else
            {
                m = db.ObavijestKategorija.Where(o => o.ObavijestID == x.ObavijestID).SingleOrDefault();
            }
            m.Naziv = x.Naziv;
            db.SaveChanges();
            return Redirect("/ObavijestKategorija/Prikaz");
        }
        public IActionResult Obrisi(int ObavijestID)
        {
            var m=db.ObavijestKategorija.Find(ObavijestID);
            db.Remove(m);
            db.SaveChanges();
            return Redirect("/ObavijestKategorija/Prikaz");
        }
    }
}